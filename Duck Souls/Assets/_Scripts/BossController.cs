using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //Other Scripts
    CanvasController canvasController;

    //Shooting Variables
    public Transform bossAttackOrigin;
    public Transform playerPosition;
    public GameObject fireball;
    public float bossFireRate = 1f;
    private float canFire = 0f;

    //Healthbar Variables
    public int bossMaxHealth;
    public int bossCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        canvasController = GameObject.Find("DUCK UI").GetComponent<CanvasController>();
        canvasController.SetBossMaxHealth(bossMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPosition);
        //transform.LookAt(playerPosition, Vector3.left);
        if (Time.time > canFire)    //if gametime is longer than canFire
        {
            Instantiate(fireball, bossAttackOrigin.position, bossAttackOrigin.rotation);
            canFire = Time.time + (1 / bossFireRate);
        }

        if (bossCurrentHealth <= 0)
        {
            print("Game Over");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (bossCurrentHealth >= damageAmount)
        {
            bossCurrentHealth -= damageAmount;
        }
        else if (bossCurrentHealth < damageAmount && bossCurrentHealth > 0)
        {
            bossCurrentHealth = 0;
        }
        canvasController.SetBossHealth(bossCurrentHealth);
    }
}
