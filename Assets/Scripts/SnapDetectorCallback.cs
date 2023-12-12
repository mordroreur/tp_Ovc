using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapDetectorCallback : MonoBehaviour
{
    public GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            _parent.GetComponent<ObjectSnap>().IsEntered(other.gameObject);
            Destroy(_parent.GetComponent<ObjectSnap>());

            _parent = other.gameObject;
            ObjectSnap p = _parent.AddComponent<ObjectSnap>();

            other.GetComponent<Rigidbody>().isKinematic = true;
            //transform.SetParent(other.GetComponent<Transform>(), true);
        }
    }
}
