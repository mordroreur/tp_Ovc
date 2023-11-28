using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{

    [Tooltip("vitesse de rotation")]
    [Range(0, 1000)]
    public float _vitesseDeRotation = 100;

    [Tooltip("Activation de la rotation")]
    public bool _rotationOnOff = true;


    private GameObject _button;


    // Start is called before the first frame update
    void Start()
    {
        _button = GameObject.Find("TextBouttonRota");
    }

    public void RotationTogle()
    {
        _rotationOnOff = !_rotationOnOff;
  
    }

    // Update is called once per frame
    void Update()
    {
        if(_rotationOnOff)
            GetComponent<Transform>().Rotate(0, _vitesseDeRotation * Time.deltaTime, 0);

    }
}
