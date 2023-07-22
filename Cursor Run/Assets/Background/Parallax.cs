using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(1, 100)]
    public float depth = 1;
    PlayerMovement player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        SetOrderInSortingLayer();
    }

    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.deltaTime; //goes opposite direction of player to show speed

        if (pos.x <= -20)
        {
            pos.x = 20;
            pos.y = Random.Range(-4.8f, 4f);
        }
            

        transform.position = pos;
    }

    void SetOrderInSortingLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -Mathf.FloorToInt(depth * 10);
    }
}
