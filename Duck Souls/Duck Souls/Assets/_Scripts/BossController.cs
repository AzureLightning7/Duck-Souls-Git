using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //Other Scripts
    CanvasController canvasController;  //variable for canvas controller

    //Boss Raycast Variables

    //Boss Attacking Variables
    public Transform playerPosition;    //variable for the position of the player objects
    private string bossAttackState = "Shoot";    //variable that stores the current state the boss is in
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
    public float bossFireRate = 0.5f;     //the number of projectiles the boss will fire in one second

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
        if (canAttack == true)                  //check if boss can attack
        {
            switch (bossAttackState)            //check which attaack state boss is currently in
            {
                case "diesofcutscene":
                    //Boss enters charging phase
                    canAttack = false;          //set canAttack to false to prevent multiple attacks running simultaneously
                    Charge();
                    break;

                case "Shoot":
                    //Boss enters shooting phase
                    canAttack = false;          //prevent boss starting a new attack every frame
                    StartCoroutine(Shoot());    //call shoot coroutine/function
                    break;
            }
        }
        

        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        if (isCharging == false)
        {
            transform.LookAt(playerPosition);
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
        isCharging = true;
        Invoke("StopCharging", bossChargeTime);
    }

    void StopCharging()
    {
        isCharging = false;
        Invoke("CanAttackTrue", 3);
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bossProjectile, bossAttackOrigin.position, bossAttackOrigin.rotation);
            yield return new WaitForSeconds(1 / bossFireRate);
        }
        StopShooting();
    }

    void StopShooting()
    {
        StopCoroutine(Shoot());
        Invoke("CanAttackTrue", 3);
    }

    void CanAttackTrue()
    {
        print("RESET");
        canAttack = true;
    }

    void AttackStateCharge()
    {
        bossAttackState = "Charge";
    }

    void AttackStateShoot()
    {
        bossAttackState = "Shoot";
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