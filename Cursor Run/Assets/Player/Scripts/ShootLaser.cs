using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    public float cooldownTime;
    [SerializeField]
    private float cooldownTimer = 0;

    void Update()
    {
        if (cooldownTimer >= cooldownTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
                AudioManager.instance.PlaySound("laser");
                cooldownTimer = 0;
            }
        }
        cooldownTimer += Time.deltaTime;
    }
}
