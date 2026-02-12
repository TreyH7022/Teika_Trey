using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float timeout;
    private float timeStart;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Top")) {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Top")) {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;

            if (timeThusFar > timeout) {
                print("Game Over Dude");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Top")) {
            timeStart = 0.0f;
        }
    }
}
