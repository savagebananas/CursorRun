using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float flashDuration;

    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("ow");
        animator.SetTrigger("hit");
        StartCoroutine(Flash(GetComponent<SpriteRenderer>(), flashDuration, Color.white));
    }

    private IEnumerator Flash(SpriteRenderer spriteRend, float duration, Color flashColor)
    {
        Color originalColor = spriteRend.color;
        spriteRend.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRend.color = originalColor;

    }
}
