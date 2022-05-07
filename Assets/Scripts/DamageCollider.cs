using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    PlayerStats playerStats;
    EnemyStats enemyStats;

    public int currentWeaponDamage = 25;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollidor()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollidor()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            playerStats = collision.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if(collision.tag == "Enemy")
        {
            enemyStats = collision.GetComponent<EnemyStats>();
            if(enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
