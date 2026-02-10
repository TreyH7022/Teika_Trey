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
        move = 0; // 0 means you can move both ways
    }

    void Update() {
        
        if(currentBall != null) {
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f,yOff,0.0f);
            currentBall.transform.position = playerPos + ballOffset; 
        } else if (ball.Length > 0) {
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

     /*   float offset = 0.0f;
        bool left = (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) && move != 1;
        if(left == true) {
            offset = -speed;
        } */

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        } 

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        }

        public void OnCollisionEnter2D(Collision2D other) {
            if(other.GameObject.CompareTag("LB")) {
                move = 1; // cannot move left
            }
        }
    }
}