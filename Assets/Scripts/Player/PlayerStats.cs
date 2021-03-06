using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
   

    public HealthBar healthBar;
    public GameObject gameOverPanel;
    AnimatorHandler animatorHandler;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();    
    }

    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);
            animatorHandler.PlayTargetAnimation("TakeDamage", true);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Death", true);
                gameOverPanel.SetActive(true);
            }
        }
    }

    public void HealDamage(int value)
    {
        currentHealth = currentHealth + value;
        healthBar.SetCurrentHealth(currentHealth);
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }
}
