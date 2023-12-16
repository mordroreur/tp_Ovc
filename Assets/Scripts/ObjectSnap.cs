using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsEntered(GameObject other)
    {

        
        other.GetComponent<Transform>().SetParent(GetComponent<Transform>().Find("NextPose"), true);
        //other.GetComponent<Transform>().localScale = new Vector3(1 / 0.8f, 1.0f / 0.3f, 1 / 0.8f);
        other.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        other.GetComponent<Transform>().localRotation = Quaternion.Euler(0, other.GetComponent<Transform>().rotation.eulerAngles.y, 0);
        other.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);


        //Destroy(other.GetComponent<Rigidbody>());

    }
}
