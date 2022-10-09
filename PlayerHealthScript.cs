using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthText;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealthText(int health, int maxHealth)
    {
        healthText.text = "" + health + "/" + maxHealth;
    }
}
