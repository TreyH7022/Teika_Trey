using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float timeout;
    private float timeStart;

    // OnTriggerEnter2D()
    // OnTriggerExit2D()
    // OnTriggerStay2D()

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collision2D other) {
        
        if (other.GameObject.CompareTag("Top")) {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collision2D other) {
        if (other.GameObject.CompareTag("Top")) {
        float currentTime = Time.time;
        float timeThusFar = currentTime - timeStart;
        if (timeThusFar > timeout) {
            print ("Game Over Dude");
        }
        }
    }

    private void OnTriggerExit2D(Collision2D other) {
        if (other.GameObject.CompareTag("Top")) {
        timeStart = 0.0f;
        }
    }


}