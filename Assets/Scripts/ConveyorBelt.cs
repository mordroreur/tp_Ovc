using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool activated;

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!activated) return;
        
        if (!rigidBody) return;

        Vector3 pos = rigidBody.position;

        rigidBody.position -= (transform.forward.normalized * speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(pos);
    }

    public void ConveyorMode(bool activated)
    {
        this.activated = activated;
    }
}
