using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    public float _speed = 10.0f;
    private float _increment;
    private Transform _tfBody;
    // Start is called before the first frame update
    void Start()
    {
        _tfBody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _increment = _speed * Time.deltaTime;

        _tfBody.Translate(Input.GetAxis("Horizontal") * _increment, 0, Input.GetAxis("Vertical") * _increment);
    }
}
