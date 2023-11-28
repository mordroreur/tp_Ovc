using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : MonoBehaviour
{
    public float _speed = 10.0f;
    public float _jump = 100.0f;
    public float _mouseSensitivity = 10.0f;
    public GameObject _camera;


    private float _increment;
    private Transform _tfBody;
    private bool _cursor;


    private float _yRot;
    private float _xRot;


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



        _yRot = 0.0f;
        _xRot = 0.0f;

        _tfBody = GetComponent<Transform>();
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

        _tfBody.Translate(Input.GetAxis("Horizontal") * _increment, 0, Input.GetAxis("Vertical") * _increment);

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
