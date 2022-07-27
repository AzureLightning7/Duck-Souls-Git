using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Slider playerHealthSlider;
    public Slider bossHealthSlider;

    public void SetPlayerMaxHealth(int playerMaxHealth)
    {
        playerHealthSlider.maxValue = playerMaxHealth;
        playerHealthSlider.value = playerMaxHealth;
    }

    public void SetPlayerHealth(int playerHealth)
    {
        playerHealthSlider.value = playerHealth;
    }

    public void SetBossMaxHealth(int bossMaxHealth)
    {
        bossHealthSlider.maxValue = bossMaxHealth;
        bossHealthSlider.value = bossMaxHealth;
    }

    public void SetBossHealth(int bossHealth)
    {
        bossHealthSlider.value = bossHealth;
    }
}
