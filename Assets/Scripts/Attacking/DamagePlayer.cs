using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 25;
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
       if(playerStats != null)
        {
            playerStats.TakeDamage(damage);
        }
    }
}
