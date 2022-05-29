using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public BoxCollider boxCollider;

    public void EnableCollidor()
    {
        boxCollider.enabled = true;
    }

    public void DisableCollidor()
    {
        boxCollider.enabled = false;
    }
}
