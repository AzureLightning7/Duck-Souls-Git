using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    //Player Health Variables
    public int playerMaxHealth = 3; //max health of the player
    public int currentHealth;       //variable that stores current health of the player

    //Shard Variables
    public float speedIncreaseMultiplier = 1.5f;    //multiplier for the player's speed when player picksup blue shard

    //Hoverboard Variables
    public GameObject hoverboardAfterburner;        //gameobject for afterburner
    public bool speedBoostActive = false;           //does the player start with speed boost active
    public float speedBoostDuration = 5f;           //duration of the speed boost

    CanvasController canvasController;              //canvas controller
    FirstPersonController firstPersonController;    //get reference to firstpersoncontroller script

    // Start is called before the first frame update
    void Start()
    {
        canvasController = GameObject.Find("DUCK UI").GetComponent<CanvasController>(); //reference the canvascontroller script
        currentHealth = playerMaxHealth;                                                //set the player's current health to the max health on start

        firstPersonController = GameObject.Find("THE DUCK").GetComponent<FirstPersonController>();  //reference the FPC script

        hoverboardAfterburner.SetActive(speedBoostActive);  //set the afterburner active status to what the user chooses with speedBoostActive
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)     //if player's current health reaches, execute death code
        {
            print("Game Over");
        }
    }

    // If the player comes into contact with another collider
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireball")    //if player touches a fireball
        {
            if (currentHealth <= playerMaxHealth && currentHealth > 0)    //if player health is between 0 and max health inclusive, decrease health by one and set health bar to current health
            {
                currentHealth--;
                canvasController.DisableLatestHeart(currentHealth);
            }
        }
        else if (other.tag == "Small Healthpack")   //if player touches a small health pack
        {
            if (currentHealth < playerMaxHealth && currentHealth > 0)     //if player health is under max health but not dead, increase health by 1 and set health bar to current health
            {
                currentHealth++;
                canvasController.EnableEarliestHeart(currentHealth);
            }         
        }
        else if (other.tag == "Large Healthpack")   //if player touches a large health pack
        {
            if (currentHealth < playerMaxHealth && currentHealth > 0)     //if player health is under max health but not dead, increase health to max health and set health bar to current health
            {   while (currentHealth < playerMaxHealth)
                {
                    currentHealth++;
                    canvasController.EnableEarliestHeart(currentHealth);
                }
            }
        }
        else if (other.tag == "Blue Shard")     //if player touches a blue shard
        {
            firstPersonController.IncreaseSpeed(speedIncreaseMultiplier);   //multiply speed by the speed multiplier
            hoverboardAfterburner.SetActive(true);                          //set the afterburner to active
            Invoke("StopSpeedBoost", speedBoostDuration);                   //call stop speed boost function after duration amount of seconds
        }
    }

    void StopSpeedBoost()
    {
        firstPersonController.IncreaseSpeed(1 / speedIncreaseMultiplier);   //multiply the increased by the recipropcal of the multiplier to reset it back to it's original value
        hoverboardAfterburner.SetActive(false);                             //set the afterburner to inactive
    }
}
