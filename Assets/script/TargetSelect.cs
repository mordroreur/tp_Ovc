using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out outline))
        {
            outline.enabled = false;
            outline.OutlineWidth = 5;
        }
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
        transform.parent = grabberTf;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    public void Drop()
    {

    }

    public void Activate()
    {

    }

    public void Interact(Transform grabberTf)
    {
        if(CompareTag("Grabbable")) Grab(grabberTf);
        else if(CompareTag("Activatable")) Activate();
    }
}
