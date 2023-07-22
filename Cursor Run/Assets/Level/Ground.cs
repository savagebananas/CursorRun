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

    bool didGenerateGround = false;

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

        GameObject g = Instantiate(gameObject);

        BoxCollider2D gCollider = g.GetComponent<BoxCollider2D>();

        Vector2 pos;
        pos.x = screenRight.position.x + 5;
        pos.y = transform.position.y;
        g.transform.position = pos;

        Ground ground = g.GetComponent<Ground>();
        ground.groundHeight = g.transform.position.y + (ground.collider.size.y / 2);
    }
}
