using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Spike(Clone)")
        {
            StartCoroutine(PlayerDeath());
            hasDied = true;
        }
    }


    IEnumerator PlayerDeath()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        gameObject.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        AudioManager.instance.PlaySound("Player Dead");
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
    }
}
