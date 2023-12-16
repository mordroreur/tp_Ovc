using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float _moveSpeed = 7;

    public float _groundDrag = 5;

    public float _jumpForce = 12;
    public float _jumpCooldown = 0.25f;
    public float _airMultiplier = 0.4f;

    private bool _canJump;

    [Header("Keybinds")]
    public KeyCode _jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float _playerHeight;
    bool _isGrounded;

    public Transform _orientation;

    float _horizontalInput;
    float _verticalInput;

    Vector3 _moveDirection;

    Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;

        _canJump = true;

    }

    private void Update()
    {
        // ground check
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.51f );



        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(_jumpKey) && _isGrounded)
        {

            Jump();
            _canJump = false;

        }
        else if(_isGrounded && !_canJump)
        {
            Invoke(nameof(ResetJump), _jumpCooldown);
        }

        Vector3 flatVel = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > _moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _moveSpeed;
            _rigidBody.velocity = new Vector3(limitedVel.x, _rigidBody.velocity.y, limitedVel.z);
        }

        // handle drag
        if (_isGrounded)
            _rigidBody.drag = _groundDrag;
        else
            _rigidBody.drag = 0;



        // calculate movement direction
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        float _increment =  _moveSpeed*Time.deltaTime*30;

        // on ground
        if (_isGrounded) 
        {
            _rigidBody.AddForce(_moveDirection.normalized * _increment * 10f, ForceMode.Force);

        }// in air
        else if (!_isGrounded)
        {
            _rigidBody.AddForce(_moveDirection.normalized * _increment * 10f * _airMultiplier, ForceMode.Force);
        }

    }


    private void Jump()
    {
        // reset y velocity
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);

        _rigidBody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        _canJump = true;
    }

}
