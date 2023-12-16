using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    private Outline outline;
    private Transform _oldParent;
    private bool _isKinematic;
    private bool _hasCollision;
    private bool _isSanappable;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out outline))
        {
            outline.enabled = false;
            outline.OutlineWidth = 5;
        }

        if(TryGetComponent(out Rigidbody _myRb))
        {
            _isKinematic = _myRb.isKinematic;
            _hasCollision = _myRb.detectCollisions;
        }

        _oldParent = transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Target()
    {
        if (outline) outline.enabled = true;
    }

    public void Untarget()
    {
        if (outline) outline.enabled = false;
    }

    public void Grab(Transform grabberTf)
    {
        //transform.parent = grabberTf;
        transform.SetParent(grabberTf, true);
        transform.localScale = Vector3.one * 2;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    public void Drop()
    {
        //transform.parent = _oldParent;
        transform.SetParent(_oldParent, true);
        transform.localScale = Vector3.one;
        GetComponent<Rigidbody>().isKinematic = _isKinematic;
        GetComponent<Rigidbody>().detectCollisions = _hasCollision;
        if(_isSanappable) transform.gameObject.tag = "Snappable";
    }

    public void Interact(Transform grabberTf)
    {
        if (CompareTag("Grabbable")) 
        {
            _isSanappable = false;
            Grab(grabberTf); 
        }
        else if (CompareTag("Snappable")) 
        {
            _isSanappable = true;
            Grab(grabberTf);
            transform.gameObject.tag = "Grabbable";

        }
        else if (TryGetComponent(out ActivateBehaviour _myBehaviour)) _myBehaviour.Activate();
    }
}
