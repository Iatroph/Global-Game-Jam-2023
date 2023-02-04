using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [HideInInspector] public bool isGrounded;
    bool exitingSlope;

    float horizontalInput; // A & D
    float verticalInput; // W & S

    Vector3 moveDir;

    RaycastHit slopeHit; 
    [HideInInspector] public float currentMoveSpeed;
    float jumpCoolDown = 0.1f;

    [Header("Object References")]
    public Camera playerCam;
    public GameObject playerObj;
    public Transform orientation;

    [Header("Movement Parameters")]
    public float moveSpeed;
    public float moveMultiplier;
    public float airSpeed;
    public float airMultiplier;
    public float jumpForce;
    public float drag;
    public float gravity;

    [Header("Other Settings")]
    public float maxSlopeAngle;

    [Header("Keybinds")]
    public KeyCode jumpKey;

    [Header("Layermasks")]
    public LayerMask whatIsNotGround;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
        GroundCheck();
        UpdateDrag();
        UpdateMoveState();
        SpeedControl();

        if (OnSlope() && moveDir.magnitude == 0 && !exitingSlope && isGrounded)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyGravity();
    }

    public void UserInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(isGrounded && Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    public void ApplyMovement()
    {
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection(moveDir) * currentMoveSpeed * moveMultiplier, ForceMode.Acceleration);

            //if (rb.velocity.y > 0)
            //{
            //    rb.AddForce(Vector3.down * 150f, ForceMode.Force);
            //}

        }
        else if (isGrounded)
        { 

            rb.AddForce(moveDir.normalized * currentMoveSpeed * moveMultiplier, ForceMode.Acceleration);

        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * currentMoveSpeed * moveMultiplier * airMultiplier, ForceMode.Acceleration);
        }

    }

    public void ApplyGravity()
    {
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    public void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 2 * 0.5f + 0.4f, ~whatIsNotGround);
    }

    public void UpdateMoveState()
    {
        if (isGrounded)
        {
            currentMoveSpeed = moveSpeed;
        }
        else
        {
            currentMoveSpeed = airSpeed;
        }
    }

    public void UpdateDrag()
    {
        if (isGrounded)
        {
            rb.drag = 5;
        }
        else
        {
            rb.drag = 0;
        }
    }

    public void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > currentMoveSpeed)
            {
                rb.velocity = rb.velocity.normalized * currentMoveSpeed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //The current velocity

            if (flatVel.magnitude > currentMoveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * currentMoveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    public bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, 2 * 0.5f + 0.1f, ~whatIsNotGround))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    public void Jump()
    {
        exitingSlope = true;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        Invoke(nameof(ResetJump), jumpCoolDown);
    }

    public void ResetJump()
    {
        exitingSlope = false;
    }


}
