using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    public Transform[] spawnPoints;

    void Start()
    {

    }

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            var platform = Instantiate(platformPrefab, spawnPoints[Random.Range(0, 7)].position, Quaternion.identity);
            platform.transform.localScale = new Vector2(Random.Range(2f, 10f), 0.3f);
            timeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn <= 2f) startTimeBtwSpawn += 0.01f;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {

    }
}
