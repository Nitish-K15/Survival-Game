using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
   

    public HealthBar healthBar;
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
        currentHealth = currentHealth - damage;
        healthBar.SetCurrentHealth(currentHealth);
        animatorHandler.PlayTargetAnimation("TakeDamage", true);
        if(currentHealth<=0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Death", true);
        }
    }
}
