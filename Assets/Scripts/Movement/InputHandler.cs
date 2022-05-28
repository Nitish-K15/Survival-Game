using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    //PlayerInventory playerInventory;
    InventoryManager inventoryManager;
    PlayerManager playerManager;


    public bool b__Input;
    public bool lAttack;
    public bool hAttack;
    public bool rollFlag;
    public bool comboFlag;
    public bool d_Pad_Left;
    public bool d_Pad_Right;
    public bool inventory;
    


    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponent<PlayerAttacker>();
        inventoryManager = GetComponent<InventoryManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

   


    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollingInput(delta);
        HandleAttackInput(delta);
        HandleInventoryInput();
        //HandleQuickSlotInput();
    }

    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleRollingInput(float delta)
    {
        b__Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Performed;

        if(b__Input)
        {
            rollFlag = true;
        }
    }

    private void HandleAttackInput(float delta)
    {
        inputActions.PlayerActions.LightAttack.performed += i => lAttack = true;
        inputActions.PlayerActions.HeavyAttack.performed += i => hAttack = true;

        if(lAttack)
        {
            if (playerManager.canDoCombo)
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombos(inventoryManager.weapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;
                if (playerManager.canDoCombo)
                    return;
                playerAttacker.HandleLightAttack(inventoryManager.weapon);
            }
        }

        if(hAttack)
        {
            if (playerManager.canDoCombo)
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombos(inventoryManager.weapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;
                if (playerManager.canDoCombo)
                    return;
                playerAttacker.HandleHeavyAttack(inventoryManager.weapon);
            }
        }
    }

    private void HandleInventoryInput()
    {
        inputActions.PlayerActions.Inventory.performed += i => inventory = !inventory;

        if(inventory)
        {
            inventoryManager.inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryManager.inventoryPanel.SetActive(false);
        }
    }
    //private void HandleQuickSlotInput()
    //{
    //    inputActions.PlayerActions.DPadRight.performed += i => d_Pad_Right = true;
    //    inputActions.PlayerActions.DPadLeft.performed += i => d_Pad_Left = true;
    //    if(d_Pad_Right)
    //    {
    //        playerInventory.ChangeRightWeapon();
    //    }

    //    else if(d_Pad_Left)
    //    {
    //        //playerInventory.ChangeLeftWeapon();
    //    }
    //}
}
