using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform bossAttackOrigin;
    public Transform playerPosition;
    public GameObject fireball;
    public float fireRate = 1f;
    private float canFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerPosition);
        //transform.LookAt(playerPosition, Vector3.left);
        if (Time.time > canFire)    //if gametime is longer than canFire
        {
            Instantiate(fireball, bossAttackOrigin.position, bossAttackOrigin.rotation);
            canFire = Time.time + (1 / fireRate);
        }
    }
}
