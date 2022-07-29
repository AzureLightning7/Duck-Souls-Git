using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    //player health variables
    private GameObject heart1;   //all three heart GameObjects
    private GameObject heart2;
    private GameObject heart3;

    public Slider bossHealthSlider; //slider that controls the boss health bar

    // Start is called before the first frame update
    void Start()
    {
        heart1 = GameObject.Find("Heart 1");    //find all three Hearts at start
        heart2 = GameObject.Find("Heart 2");
        heart3 = GameObject.Find("Heart 3");
    }

    //Function that will disable the most right health bar
    public void DisableLatestHeart(int newHealth)
    {
        if (newHealth == 2)             //if health is going from 3 to 2, disable 3rd heart
        {
            heart3.SetActive(false);
        }
        else if (newHealth == 1)        //if health is going from 2 to 1, disable d heart
        {
            heart2.SetActive(false);
        }
        else                            //if health is going from 1 to 0, disable 1st heart
        {
            heart1.SetActive(false);
        }
    }

    public void EnableEarliestHeart(int newHealth)
    {
        if (newHealth == 3)             //if health is going from 2 to 3, enable 3rd heart
        {
            heart3.SetActive(true);
        }
        else if (newHealth == 2)        //if health is going from 1 to 2, enable 2nd heart
        {
            heart2.SetActive(true);
        }
        else                            //if health is going from 0 to 1 (rez item used), enable 1st heart
        {
            heart1.SetActive(true);
        }
    }

    public void SetBossMaxHealth(int bossMaxHealth) //Set the boss's max health to the inputed max health value, and set current health to max health
    {
        bossHealthSlider.maxValue = bossMaxHealth;
        bossHealthSlider.value = bossMaxHealth;
    }

    public void SetBossHealth(int bossHealth)       //Set the boss's current health to the new value inputed into the function
    {
        bossHealthSlider.value = bossHealth;
    }
}
