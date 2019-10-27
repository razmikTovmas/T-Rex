using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] grounds;
    public Transform groundsSpawnPoint;

    float counter = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0.0f)
        {
            GenerateRandomGround();
            counter = 1.2f;
        }
        else
        {
            counter -= Time.deltaTime;
        }
        // Scrolling
        GameObject currentChild;
        for (int i = 0; i < transform.childCount; ++i)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if (currentChild.transform.position.x < -12.0f)
            {
                Destroy(currentChild);
            }
        }
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomGround()
    {
        GameObject ground = Instantiate(grounds[Random.Range(0, grounds.Length)],
                                           groundsSpawnPoint.position,
                                           Quaternion.identity) as GameObject;
        ground.transform.parent = transform;
    }
}
