using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float timeThusFar;

    public GameObject[] ball;
    public int ballType;

    void Start() {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<TestBehavior>().ball;
    }

    void Update() {
        
    // }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("Top")) {
    //         timeStart = Time.time;
    //     }
    // }

    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("Top")) {
    //         float currentTime = Time.time;
    //         float timeThusFar = currentTime - timeStart;

    //         if (timeThusFar > timeout) {

    //             print("Game Over Dude");
    //         }
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("Top")) {
    //         timeStart = 0.0f;
    //     }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            int otherType = other.gameObject.GetComponent<NewMonoBehaviourScript>().ballType;
            if (otherType == ballType && ballType < ball.Length-1) {
                if (gameObject.transform.position.x < other.transform.position.x 
                    || (gameObject.transform.position.x == other.transform.position.x 
                        && gameObject.transform.position.y >= other.transform.position.y)) {
                    
                    // Create the merged one
                    int index = ballType + 1;
                    GameObject currentBall = Instantiate(ball[index], Vector3.Lerp(gameObject.transform.position,
                        other.gameObject.transform.position, 0.5f), Quaternion.identity);
                    currentBall.GetComponent<Collider2D>().enabled = true;
                    currentBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<TestBehavior>().updateScore(ballType);

                    // destroy both things
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}

/*
points when merged
Tennis Ball 1
8 ball 3
baseball 5
Puck 8
Basketball 10
Soccer Ball 15
Football 25
Bowling ball 50
*/