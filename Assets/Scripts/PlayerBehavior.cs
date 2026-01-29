using UnityEngine;
using UnityEngine.InputSystem;

public class TestBehavior : MonoBehaviour
{
    public float speed;
    public GameObject ball;
    public float yOff = -0.5f;

    void Start() {
    
    }

    void Update() {
        
        if(ball != null) {
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f,yOff,0.0f);
            ball.transform.position = playerPos + ballOffset; 
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            Rigidbody2D body = ball.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = ball.GetComponent<Collider2D>();
            collider.enabled = true;
            ball = null;
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