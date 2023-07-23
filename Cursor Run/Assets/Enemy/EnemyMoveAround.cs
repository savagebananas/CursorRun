using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAround : State
{
    private PlayerMovement player;
    public GameObject enemy;
    public float enemySpeed;
    public float cooldownDuration;

    public float nextGroundHeight;

    [SerializeField]
    private Vector2 nextRoamPosition;

    public override void OnLateUpdate()
    {
        
    }

    public override void OnStart()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        SearchWalkPoint();
    }

    public override void OnUpdate()
    {
        Roam();
    }

    void Roam()
    {
        if ((Vector2)transform.position != (Vector2)nextRoamPosition) //if not at location, move towards it
        {
            moveTowardsRoamPoint();
        }
        if((Vector2)transform.position == (Vector2)nextRoamPosition) //once reached target location, cooldown before finding new location
        {
            Debug.Log(1);
            StartCoroutine(roamingCooldown());
        }
    }

    void moveTowardsRoamPoint()
    {

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, nextRoamPosition, enemySpeed * Time.deltaTime);
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(5.0f, 11.0f);
        float randomY = Random.Range(nextGroundHeight + 0.25f, 4.5f);
        nextRoamPosition = new Vector2(randomX, randomY);
    }

    private IEnumerator roamingCooldown()
    {
        var timeBetweenRoams = cooldownDuration + Random.Range(-1, 1);
        yield return new WaitForSeconds(timeBetweenRoams);
        SearchWalkPoint();
    }
}
