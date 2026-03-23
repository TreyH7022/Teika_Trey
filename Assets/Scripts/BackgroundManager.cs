using UnityEngine;

public class DiagonalBackground : MonoBehaviour
{
    public float speedX = 1f; 
    public float speedY = 1f; 
    public Vector2 resetPosition; 
    public Vector2 startPosition; 

    private Vector2 size; 

    void Start()
    {
        transform.position = startPosition;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            size = sr.bounds.size;
        }
    }

    void Update()
    {
        // Move diagonally
        transform.Translate(new Vector3(speedX, speedY, 0) * Time.deltaTime);

        // Resets if it goes to far
        if (transform.position.x > resetPosition.x || transform.position.y > resetPosition.y)
        {
            transform.position = startPosition;
        }
    }
}