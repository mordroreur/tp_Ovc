using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeObject : MonoBehaviour
{

    public GameObject _zone;
    public GameObject _thePrefab;

    private int _uniqueId;

    void CreatePrefab()
    {
        _uniqueId = Instantiate(_thePrefab, GetComponent<Transform>().position+Vector3.down*1, Quaternion.identity).GetInstanceID();
    }


    // Start is called before the first frame update
    void Start()
    {
        CreatePrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetInstanceID() == _uniqueId)
        {
            CreatePrefab();
        }
    }
}
