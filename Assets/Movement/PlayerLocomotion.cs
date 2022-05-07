using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Transform cameraObject;
    InputHandler inputHandler;
    PlayerManager playerManager;
    public Vector3 moveDirection;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorHandler animatorHandler;

    public new Rigidbody rigidbody;
    public GameObject normalCamera;

    [Header("Ground & Air Detection stats")]
    [SerializeField]
    float groundDetectionRayStartPoint = 0.5f;
    [SerializeField]
    float minimumFallDistance = 1;
    [SerializeField]
    float groundDirectionRayDistance = 0.2f;
    LayerMask ignoreForGroundCheck;
    public float inAirTimer;


    [Header("Movement Stats")]
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float rotationSpeed = 10;
    [SerializeField]
    float fallingSpeed = 45;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        cameraObject = Camera.main.transform;
        myTransform = transform;
        animatorHandler.Initialize();

        playerManager.isGrounded = true;
        ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
    }

    #region Movemment
    Vector3 normalVector;
    Vector3 targetPosition;

    private void HandleRotation(float delta)
    {
        Vector3 targetdir = Vector3.zero;
        float moveOverride = inputHandler.moveAmount;

        targetdir = cameraObject.forward * inputHandler.vertical;
        targetdir += cameraObject.right * inputHandler.horizontal;

        targetdir.Normalize();
        targetdir.y = 0;

        if (targetdir == Vector3.zero)
            targetdir = myTransform.forward;

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetdir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }

    public void HandleMovement(float delta)
    {
        if (inputHandler.rollFlag)
            return;
        if (playerManager.isInteracting)
            return;
        moveDirection = cameraObject.forward * inputHandler.vertical;
        moveDirection += cameraObject.right * inputHandler.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;
        moveDirection *= speed;

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVelocity;

        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0);
        if (animatorHandler.canRotate)
        {
            HandleRotation(delta);
        }

    }

    public void HandleRollingAndSprinting(float delta)
    {
      if (animatorHandler.anim.GetBool("isInteracting"))
        {
            return;
        }

        if (inputHandler.rollFlag)
        {
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            if (inputHandler.moveAmount > 0)
            {
                animatorHandler.PlayTargetAnimation("Rolling", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
            }
        }
    }

    public void HandleFalling(float delta,Vector3 moveDirection)
    {
        playerManager.isGrounded = false;
        RaycastHit hit;
        Vector3 origin = myTransform.position;
        origin.y += groundDetectionRayStartPoint;

        if(Physics.Raycast(origin,myTransform.forward,out hit,0.4f))
        {
            moveDirection = Vector3.zero;
        }

        if(playerManager.isInAir)
        {
            rigidbody.AddForce(-Vector3.up * fallingSpeed);
            rigidbody.AddForce(moveDirection * fallingSpeed / 5f);
        }

        Vector3 dir = moveDirection;
        dir.Normalize();
        origin = origin + dir * groundDirectionRayDistance;
        targetPosition = myTransform.position;

        Debug.DrawRay(origin, -Vector3.up * minimumFallDistance, Color.red, 0.1f, false);
        if(Physics.Raycast(origin,-Vector3.up,out hit,minimumFallDistance,ignoreForGroundCheck))
        {
            normalVector = hit.normal;
            Vector3 tp = hit.point;
            playerManager.isGrounded = true;
            targetPosition.y = tp.y;

            if(playerManager.isInAir)
            {
                if(inAirTimer > 0.1f)
                {
                    Debug.Log(inAirTimer);
                    animatorHandler.PlayTargetAnimation("Land", true);
                    inAirTimer = 0;
                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Empty", false);
                    inAirTimer = 0;
                }

                playerManager.isInAir = false;
            }
        }
        else
        {
            if(playerManager.isGrounded)
            {
                playerManager.isGrounded = false;
            }
            if(playerManager.isInAir == false)
            {
                if(playerManager.isInteracting == false)
                {
                    animatorHandler.PlayTargetAnimation("Falling", true);
                }

                Vector3 vel = rigidbody.velocity;
                vel.Normalize();
                rigidbody.velocity = vel * (movementSpeed / 2);
                playerManager.isInAir = true;
            }
        }

        if(playerManager.isGrounded)
        {
            if(playerManager.isInteracting || inputHandler.moveAmount > 0)
            {
                myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, Time.deltaTime);
            }
            else
            {
                myTransform.position = targetPosition;
            }
        }
    }
    #endregion

}
