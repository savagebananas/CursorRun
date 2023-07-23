using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    PlayerMovement player;

    public float groundHeight;
    public float groundRight;
    public Transform screenRight;
    BoxCollider2D collider;

    public bool didGenerateGround = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (transform.localScale.y/2);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;

        groundRight = transform.position.x + (transform.localScale.x / 2);

        if(groundRight < -20)
        {
            Destroy(gameObject);
        }

        if (!didGenerateGround)
        {
            if (groundRight < screenRight.position.x)
            {
                GenerateGround();
            }
        }

        transform.position = pos;
    }

    void GenerateGround()
    {
        didGenerateGround = true;

        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;

        float h1 = player.jumpVelocity * player.maxHoldJumpTime;
        float t = player.jumpVelocity / -player.gravity;
        float h2 = player.jumpVelocity * t + (0.5f * (player.gravity * (t * t)));
        float maxJumpHeight = h1 + h2;
        float maxY = maxJumpHeight * 0.7f;
        maxY += groundHeight;
        float minY = -3f;
        float actualY = Random.Range(minY, maxY);

        pos.y = actualY - transform.localScale.y / 2;
        if (pos.y > 2.7f)
            pos.y = 2.7f;

        float t1 = t + player.maxHoldJumpTime;
        float t2 = Mathf.Sqrt((2.0f * (maxY - actualY)) / -player.gravity);
        float totalTime = t1 + t2;
        float maxX = totalTime * player.velocity.x;
        maxX *= 0.7f;
        maxX += groundRight;
        float minX = screenRight.position.x + 5;
        float actualX = Random.Range(minX, maxX);

        pos.x = actualX + transform.localScale.x / 2;
        go.transform.position = pos;

        Ground goGround = go.GetComponent<Ground>();
        goGround.groundHeight = go.transform.position.y + (transform.localScale.y / 2);
        goGround.didGenerateGround = false;
    }
}
