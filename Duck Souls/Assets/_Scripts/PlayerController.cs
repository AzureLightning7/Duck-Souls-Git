using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerMaxHealth = 3;
    private int currentHealth;

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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireball")
        {
            currentHealth--;
            canvasController.DisableLatestHeart(currentHealth);
        }
        else if (other.tag == "Small Healthpack")
        {
            currentHealth++;
            canvasController.EnableEarliestHeart(currentHealth);
        }
        else if (other.tag == "Large Healthpack")
        {
            while (currentHealth < playerMaxHealth)
            {
                currentHealth++;
                canvasController.EnableEarliestHeart(currentHealth);
            }
        }
    }
}
