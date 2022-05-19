using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class LoadSiegeWeapon : MonoBehaviour
    {
        [SerializeField]
        SiegeWeaponFire weapon;

        // TODO: events? better way than having this coupling
        [SerializeField]
        PickupItem playerCarry;

        [SerializeField]
        string validTag = "catapult_bullet";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(validTag))
            {
                if (weapon.isReady)
                {
                    playerCarry.Drop();
                    weapon.LoadBullet(other.gameObject);
                }
            }
        }
    }
}
