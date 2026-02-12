using UnityEngine;
using UnityEngine.InputSystem;

public class TestBehavior : MonoBehaviour
{
    public float speed;
    public GameObject[] ball;
    private GameObject currentBall;
    public float yOff = -0.5f;
    float startTime = 0.0f;
    public int move;

    void Start() {
        startTime = 0.0f;
        move = 0; // 0 = can move both ways
    }

    void Update() {
        
        if(currentBall != null) {
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f,yOff,0.0f);
            currentBall.transform.position = playerPos + ballOffset; 
        } 
        else if (ball.Length > 0) {
            int index = Random.Range(0, ball.Length);
            currentBall = Instantiate(ball[index], transform.position, Quaternion.identity);
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame && currentBall != null) {
            Rigidbody2D body = currentBall.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentBall.GetComponent<Collider2D>();
            collider.enabled = true;

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
}
