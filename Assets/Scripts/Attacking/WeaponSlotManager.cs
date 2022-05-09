using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    [SerializeField]
    WeaponHolderSlot leftHandSlot;
    [SerializeField]
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftDamageCollidor;
    DamageCollider rightDamageCollidor;


    private void Awake()
    {
        //WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        //foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        //{
        //    if(weaponSlot.isLeftHandSlot)
        //    {
        //        leftHandSlot = weaponSlot;
        //    }
        //    else if(weaponSlot.isRightHandSlot)
        //    {
        //        rightHandSlot = weaponSlot;
        //    }
        //}
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem,bool isLeft)
    {
        if(isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollidor();
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollidor();
        }
    }

    #region Handle Weapon's Damage Collidor

    private void LoadLeftWeaponDamageCollidor()
    {
        leftDamageCollidor = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollidor()
    {
        rightDamageCollidor = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenRightDamageCollidor()
    {
        rightDamageCollidor.EnableDamageCollidor();
    }

    public void OpenLeftDamageCollidor()
    {
        leftDamageCollidor.EnableDamageCollidor();
    }

    public void CloseRightDamageCollidor()
    {
        rightDamageCollidor.DisableDamageCollidor();
    }
    public void CloseLeftDamageCollidor()
    {
        leftDamageCollidor.DisableDamageCollidor();
    }

    #endregion
}
