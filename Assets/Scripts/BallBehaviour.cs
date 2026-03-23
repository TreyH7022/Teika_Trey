using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float timeThusFar;
    public bool isHeld = true;
    public AudioClip mergeSound;
    private AudioSource audioSource;

    public GameObject[] ball;
    public int ballType;

    void Start() {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<TestBehavior>().ball;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            int otherType = other.gameObject.GetComponent<NewMonoBehaviourScript>().ballType;
            if (otherType == ballType && ballType < ball.Length-1) {
                if (gameObject.transform.position.x < other.transform.position.x 
                    || (gameObject.transform.position.x == other.transform.position.x 
                        && gameObject.transform.position.y >= other.transform.position.y)) {
                    
                    int index = ballType + 1;

                    Vector3 spawnPos = Vector3.Lerp( gameObject.transform.position,
                        other.gameObject.transform.position, 0.5f);

                    Debug.Log("MERGE SOUND TRIGGERED");
                    AudioSource.PlayClipAtPoint(mergeSound, Camera.main.transform.position, 4.0f);

                    // Create merged ball
                    GameObject currentBall = Instantiate(ball[index], spawnPos, Quaternion.identity);
                    currentBall.GetComponent<Collider2D>().enabled = true;
                    currentBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

                    // Score update
                    GameObject.FindGameObjectWithTag("Player")
                        .GetComponent<TestBehavior>()
                        .updateScore(ballType);

                    // Destroy both
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