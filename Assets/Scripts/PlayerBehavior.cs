using UnityEngine;
using UnityEngine.InputSystem;

public class TestBehavior : MonoBehaviour
{
    public float speed;
    
    void Start() {
    
    }


    void Update() {
        
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