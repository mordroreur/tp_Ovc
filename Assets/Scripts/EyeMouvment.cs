using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkMovement : MonoBehaviour
{
    public float _mouseSensitivity = 400.0f;

    public Transform _orientation;
    public GameObject _escapeMenu;

    public bool _isActivetedOnStart = true;

    private float _yRot;
    private float _xRot;
    private bool _isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_isActivetedOnStart)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _escapeMenu.SetActive(false);
            _isSelected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSelected)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensitivity;

            _yRot += mouseX;
            _xRot -= mouseY;

            _xRot = Mathf.Clamp(_xRot, -90f, 90f);

            GetComponent<Transform>().rotation = Quaternion.Euler(_xRot, _yRot, 0);
            _orientation.rotation = Quaternion.Euler(0, _yRot, 0);

            if (Input.GetKeyDown("escape"))
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _escapeMenu.SetActive(true);
                _isSelected = false;
            }
        }
        


    }

    public void enterGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _escapeMenu.SetActive(false);
        _isSelected = true;
    }

}


