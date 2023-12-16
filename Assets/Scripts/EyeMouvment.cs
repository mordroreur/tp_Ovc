using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkMovement : MonoBehaviour
{
    public float _mouseSensitivity = 400.0f;

    public Transform _orientation;

    private float _yRot;
    private float _xRot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensitivity;

        _yRot += mouseX;
        _xRot -= mouseY;

        _xRot = Mathf.Clamp(_xRot, -90f, 90f);

        GetComponent<Transform>().rotation = Quaternion.Euler(_xRot, _yRot, 0);
        _orientation.rotation = Quaternion.Euler(0, _yRot, 0);
    }

}


