using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputHandler;
    Animator anim;
    CameraHandler cameraHandler;
    PlayerLocomotion playerLocomotion;
    
    [Header("Player Flags")]
    public bool isInteracting;
    public bool isInAir;
    public bool isGrounded;
    public bool canDoCombo;

    float delta;

    private void Awake()
    {
        cameraHandler = CameraHandler.singleton;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        isInteracting = anim.GetBool("isInteracting");
        canDoCombo = anim.GetBool("canDoCombo");
        delta = Time.deltaTime;
        inputHandler.TickInput(delta);
        playerLocomotion.HandleMovement(delta);
        playerLocomotion.HandleRollingAndSprinting(delta);
        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
    }

    private void FixedUpdate()
    {

        //float delta = Time.deltaTime;
        //if (cameraHandler != null)
        //{
        //    cameraHandler.FollowTarget(delta);
        //    cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        //}
    }

    private void LateUpdate()
    {
        inputHandler.rollFlag = false;
        inputHandler.lAttack = false;
        inputHandler.hAttack = false;
        if(isInAir)
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
        }
    }
}
