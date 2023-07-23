using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.fixedDeltaTime;
        transform.position = pos;

        if (transform.position.x > 20) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
