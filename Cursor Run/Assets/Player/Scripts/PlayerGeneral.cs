using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    public bool hasDied = false;
    public GameObject deathParticles;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < -10 && hasDied == false)
        {
            StartCoroutine(PlayerDeath());
            hasDied = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "damagePlayer")
        {
            StartCoroutine(PlayerDeath());
            hasDied = true;
        }
    }

    IEnumerator PlayerDeath()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
    }
}
