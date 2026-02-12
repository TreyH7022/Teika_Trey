using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    public GameObject gameOver;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;

            if (timeThusFar > timeout) {

                gameOver.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            timeStart = 0.0f;
        }
    }
}