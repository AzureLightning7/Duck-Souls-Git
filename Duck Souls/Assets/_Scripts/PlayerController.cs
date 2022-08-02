using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerMaxHealth = 3;
    public int currentHealth;

    CanvasController canvasController;

    // Start is called before the first frame update
    void Start()
    {
        canvasController = GameObject.Find("DUCK UI").GetComponent<CanvasController>();
        currentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            print("Game Over");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireball")
        {
            if (currentHealth <= 3 && currentHealth > 0)
            {
                currentHealth--;
                canvasController.DisableLatestHeart(currentHealth);
            }
        }
        else if (other.tag == "Small Healthpack")
        {
            if (currentHealth < 3 && currentHealth > 0)
            {
                currentHealth++;
                canvasController.EnableEarliestHeart(currentHealth);
            }         
        }
        else if (other.tag == "Large Healthpack")
        {
            if (currentHealth < 3 && currentHealth > 0)
            {   while (currentHealth < playerMaxHealth)
                {
                    currentHealth++;
                    canvasController.EnableEarliestHeart(currentHealth);
                }
            }
        }
    }
}
