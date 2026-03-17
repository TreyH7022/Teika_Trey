using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public Transform[] previewSlots;
    
    private GameObject[] previewObjects;
    private Queue<GameObject> ballQueue = new Queue<GameObject>();

    public int queueSize = 3;

    void Start()
    {

        // Fill queue at start
        for (int i = 0; i < queueSize; i++)
        {
            EnqueueRandomBall();
        }

        previewObjects = new GameObject[queueSize];
        UpdatePreview();
    }

    void EnqueueRandomBall()
    {
        int rand = Random.Range(0, ballPrefabs.Length);
        ballQueue.Enqueue(ballPrefabs[rand]);
    }

    public GameObject GetNextBall()
    {
        GameObject nextBall = ballQueue.Dequeue();
        EnqueueRandomBall();
        UpdatePreview();
        return nextBall;
    }

    public GameObject[] GetQueue()
    {
        return ballQueue.ToArray();
    }

    void UpdatePreview()
    {
        GameObject[] queueArray = ballQueue.ToArray();

        for (int i = 0; i < previewSlots.Length; i++)
        {
            if (previewObjects[i] != null)
            {
                Destroy(previewObjects[i]);
            }

            previewObjects[i] = Instantiate(queueArray[i], previewSlots[i].position, Quaternion.identity);

            previewObjects[i].transform.localScale = Vector3.one * 0.5f;
        }
    }

}