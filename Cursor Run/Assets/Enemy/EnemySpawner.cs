using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float difficulty;
    public GameObject enemyPrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(float seconds)
    {
        StartCoroutine(WaitForSpawn(seconds));
    }

    public IEnumerator WaitForSpawn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        var newSpider = Instantiate(enemyPrefab, new Vector2(15, 0), Quaternion.identity);
    }
}
