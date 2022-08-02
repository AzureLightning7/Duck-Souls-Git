using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //Other Scripts
    CanvasController canvasController;  //variable for canvas controller

    //Boss Attacking Variables
    public Transform playerPosition;    //variable for the position of the player objects
    private int bossAttackState = 1;    //variable that stores the current state the boss is in
    public bool canAttack = true;

    //Charging Variables
    public float bossChargeSpeed = 30f;
    public float bossChargeTime = 10f;
    public int bossChargeDamage = 2;
    private Rigidbody rb;
    private bool isCharging = false;

    //Shooting Variables
    public Transform bossAttackOrigin;  //the position of the point where the boss projectiles will spawn
    public GameObject bossProjectile;   //the projectile the boss will shoot
    public float bossFireRate = 1f;     //the number of projectiles the boss will fire in one second
    private float canFire = 0f;         //variable that is compared to Time.time to see if the boss can fire
    private int counter = 0;

    //Healthbar Variables
    public int bossMaxHealth;       //the boss's maximum health
    public int bossCurrentHealth;   //the boss's current health


    // Start is called before the first frame update
    void Start()
    {
        canvasController = GameObject.Find("DUCK UI").GetComponent<CanvasController>(); //get reference to the DUCK UI and get the script CanvasController
        canvasController.SetBossMaxHealth(bossMaxHealth);                               //tell the UI to set the boss healthbar max value as the boss's maximum health

        rb = gameObject.GetComponent<Rigidbody>();                                      //reference the Boss rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        if (isCharging == false)
        {
            transform.LookAt(playerPosition);
        }

        if (Time.time > canFire)    //if gametime is longer than canFire
        {
            if (canAttack == true && bossAttackState == 1 && counter < 3)                              //if the boss can attack, is in shooting state, and has not fired 3 times
            {
                FireProjectiles();  //Shoot balls
                counter++;                                                                          //increase counter
            }
            else if (counter == 3)
            {
                counter = 0;
                Charge();
            }
            canFire = Time.time + (1 / bossFireRate);
        }

        if (canAttack == true && bossAttackState == 0)    //if the boss can attack and is in the melee charge state
        {
            canAttack = false;
            isCharging = true;
            Invoke("StopCharging", bossChargeTime);
        }

        if (bossCurrentHealth <= 0) //if the boss's health reaches zero and he dies
        {
            print("You Win!");
        }
    }

    private void FixedUpdate()
    {
        if (isCharging == true)
        {
            //rb.velocity = transform.forward * bossChargeSpeed;
            transform.Translate(Vector3.forward * Time.deltaTime * bossChargeSpeed);
        }
    }

    void Charge()
    {
        canAttack = true;
        bossAttackState = 0;
    }

    void StopCharging()
    {
        isCharging = false;
        canAttack = true;
        Shoot();
    }

    void Shoot()
    {
        canAttack = true;
        bossAttackState = 1;
    }

    public void FireProjectiles()
    {
        Instantiate(bossProjectile, bossAttackOrigin.position, bossAttackOrigin.rotation);
    }

    public void SetAtkTrue()
    {
        canAttack = true;
    }

    public void TakeDamage(int damageAmount)
    {
        if (bossCurrentHealth >= damageAmount)  //if the boss has more health than the amount of damage taken, then subtract damage amount from current health
        {
            bossCurrentHealth -= damageAmount;
        }
        else if (bossCurrentHealth < damageAmount && bossCurrentHealth > 0) //if boss's health is less than the damage amount but more than 0, set boss to zero (prevent negative health value)
        {
            bossCurrentHealth = 0;
        }
        canvasController.SetBossHealth(bossCurrentHealth);  //reflect the health change in the UI health bar
    }
}
