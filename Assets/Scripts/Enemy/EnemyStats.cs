using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{

    Animator animator;
    public bool isAttacked;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
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
            isAttacked = true;
            currentHealth = currentHealth - damage;
            animator.Play("TakeDamage");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Death");
                Destroy(gameObject, 3f);
            }
        }
    }
}
