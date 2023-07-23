using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;
        transform.position = pos;

        if (pos.x < -30) Destroy(gameObject);
    }
}
