using UnityEngine;
using UnityEngine.InputSystem;

public class TestBehavior : MonoBehaviour
{
    public float speed;
    public GameObject ball;
    private GameObject currentBall;
    public float yOff = -0.5f;

    void Start() {
    
    }

    void Update() {
        
        if(currentBall != null) {
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f,yOff,0.0f);
            currentBall.transform.position = playerPos + ballOffset; 
        } else {
            currentBall = Instantiate(ball, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            Rigidbody2D body = currentBall.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentBall.GetComponent<Collider2D>();
            collider.enabled = true;

            currentBall = null;
        }

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

        /*
        if (Keyboard.current..isPressedThisFrame) {
        Vector3 newPos = transform.position;
        newPos.x = newPos.x + speed;
        transform.position = newPos;

        }
        */
    }
}