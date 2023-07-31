using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    public TMP_Text healthText;

    public PlayerHealth health;

    public void Start()
    {
        healthText.text = health.currentHealth.ToString() + " / " + health.maxHealth.ToString();
    }

    public void Update()
    {
        healthText.text = health.currentHealth.ToString() + " / " + health.maxHealth.ToString();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
