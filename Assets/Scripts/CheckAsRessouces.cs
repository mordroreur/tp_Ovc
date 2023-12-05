
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAsRessouces : MonoBehaviour
{
    public GameObject _creator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetInstanceID() == _creator.GetComponent<DistributeObject>().getId())
        {
            _creator.GetComponent<DistributeObject>().CreatePrefab();
        }
    }
}
