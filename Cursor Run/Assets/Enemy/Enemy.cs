using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject spiderPrefab;

    public float health;
    public float damage;
    public float flashDuration;

    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();

        AudioManager.instance.PlaySound("Spawn Spider");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeDamage(1);
        }
        if (health == 0)
        {
            StartCoroutine(Explode());
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("hit");
        StartCoroutine(Flash(GetComponent<SpriteRenderer>(), flashDuration, new Color(0, 0, 0, 200)));
    }

    private IEnumerator Flash(SpriteRenderer spriteRend, float duration, Color flashColor)
    {
        Color originalColor = spriteRend.color;
        spriteRend.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRend.color = originalColor;

    }

    private IEnumerator Explode()
    {
        health--;
        animator.SetTrigger("explode");
        AudioManager.instance.PlaySound("Dead Spider");
        yield return new WaitForSeconds(0.267f);
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().SpawnEnemy(Random.Range(3f, 5f));
        Destroy(transform.parent.gameObject);
    }
}
