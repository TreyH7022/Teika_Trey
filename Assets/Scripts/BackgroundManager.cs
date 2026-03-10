using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bckPrefab;
    public float speed;
    private GameObject[] bcks;
    public float pivotPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bcks = new GameObject[3];

        for (int i = 0; i < 0; i++) {
            float xPos = pivotPoint - (pivotPoint/2 * i);
            float yPos = pivotPoint - (pivotPoint/2 * i);

            Vector2 pos = new Vector2(0.0f, 0.0f);
            bcks[i] = Instantiate(bckPrefab, pos, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
