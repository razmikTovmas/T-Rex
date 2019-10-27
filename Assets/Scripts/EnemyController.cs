using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] enemies;
    public float frequency = 0.5f;
    public Transform enemiesSpawnPoint;

    float counter = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0.0f)
        {
            GenerateRandomEnemy();
            counter = Random.Range(1.0f, 2.0f);
        }
        else
        {
            counter -= Time.deltaTime * frequency;
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

    void GenerateRandomEnemy()
    {
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)],
                                           enemiesSpawnPoint.position,
                                           Quaternion.identity) as GameObject;
        enemy.transform.parent = transform;
    }
}
