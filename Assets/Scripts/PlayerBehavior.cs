using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TestBehavior : MonoBehaviour
{
    public float speed;
    public GameObject[] ball;
    private GameObject currentBall;
    public float yOff = -0.5f;
    public int move;
    public QueueManager queueManager;
    public AudioSource audioSource;
    public AudioClip dropSound;

    public int[] points;
    public int total;
    public TMP_Text textField;

    void Start() {
        move = 0; // 0 = can move both ways
        total = 0;

    }

    void Update() {

        if(currentBall != null) {
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f,yOff,0.0f);
            currentBall.transform.position = playerPos + ballOffset; 
        } 
        else if (queueManager != null) {
            GameObject nextBall = queueManager.GetNextBall();
            currentBall = Instantiate(nextBall, transform.position, Quaternion.identity);

            // Turn OFF physics while it's being held
            Rigidbody2D body = currentBall.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.0f;

            Collider2D collider = currentBall.GetComponent<Collider2D>();
            collider.enabled = false;
        }
        /*
        else if (ball.Length > 0) {
            int index = Random.Range(0, ball.Length);
            currentBall = Instantiate(ball[index], transform.position, Quaternion.identity);
        }
        */

        if(Keyboard.current.spaceKey.wasPressedThisFrame && currentBall != null) {
            
            audioSource.PlayOneShot(dropSound);

            Rigidbody2D body = currentBall.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentBall.GetComponent<Collider2D>();
            collider.enabled = true;

            NewMonoBehaviourScript ballScript = currentBall.GetComponent<NewMonoBehaviourScript>();
            ballScript.isHeld = false;

            currentBall = null;
        }

        if (Keyboard.current.leftArrowKey.isPressed && move != 1) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed * Time.deltaTime;
            transform.position = newPos;
        }

        if (Keyboard.current.rightArrowKey.isPressed && move != 2) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed * Time.deltaTime;
            transform.position = newPos;
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {

      //  if (isHeld) return;

        if(other.gameObject.CompareTag("LB")) {
            move = 1; // cannot move left
        }

        if(other.gameObject.CompareTag("RB")) {
            move = 2; // cannot move right
        }
    }

    public void OnCollisionExit2D(Collision2D other) {

        if(other.gameObject.CompareTag("LB") || 
           other.gameObject.CompareTag("RB")) {

            move = 0; // can move both ways again
        }
    }

    public void updateScore(int index) {
        total = total + points[index];
        textField.SetText("Score: " + total);
    }
}