using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}


/*

public class WalkMovement : MonoBehaviour
{
    public float _speed = 10.0f;
    public float _jump = 100.0f;
    
    public float _maxMoveSpeed = 12.0f;
    public GameObject _camera;


    private float _increment;
    
    private Rigidbody _rgBody;
    private bool _cursor;
    private bool _readyToJump;

   


    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionExit(Collision collision)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.lockState = CursorLockMode.Locked;
        _cursor = true;

        _readyToJump = true;

        _yRot = 0.0f;
        _xRot = 0.0f;

        _tfBody = GetComponent<Transform>();
        _rgBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _increment = _speed * Time.deltaTime;

        _yRot = (Input.GetAxis("Mouse X") * _mouseSensitivity + _yRot)%360;
        
        _tfBody.localRotation = Quaternion.AngleAxis(_yRot, Vector3.up);


        _xRot += Input.GetAxis("Mouse Y") * (_mouseSensitivity/2);
        _xRot = Mathf.Clamp(_xRot, -90, 90);
        _camera.GetComponent<Transform>().localRotation = Quaternion.AngleAxis(-_xRot, Vector3.right);

        //Debug.Log(Input.mousePosition.x);

        Vector3 flatVel = new Vector3(_rgBody.velocity.x, 0f, _rgBody.velocity.z);

        if (flatVel.magnitude > _maxMoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _maxMoveSpeed;
            _rgBody.velocity = new Vector3(limitedVel.x, _rgBody.velocity.y, limitedVel.z);
        }

        //_tfBody.Translate(Input.GetAxis("Horizontal") * _increment, 0, Input.GetAxis("Vertical") * _increment);
        _rgBody.AddForce((_tfBody.forward * Input.GetAxis("Horizontal") * _increment) + (_tfBody.right * Input.GetAxis("Vertical") * _increment), ForceMode.Force);
        Debug.Log((_tfBody.forward * Input.GetAxis("Horizontal") * _increment) + (_tfBody.right * Input.GetAxis("Vertical") * _increment));

        if (Input.GetKeyDown("escape"))
        {
            if (_cursor)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            _cursor = !_cursor;   
        }

        if (Input.GetKeyDown("space"))
        {
            if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.01)  
            {
                GetComponent<Rigidbody>().AddForce(0, _jump, 0, ForceMode.Impulse);
            }
        }
    }
}

*/