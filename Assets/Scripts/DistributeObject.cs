using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeObject : MonoBehaviour
{

    public GameObject _zone;
    public GameObject _thePrefab;

    private int _uniqueId;

    public void CreatePrefab()
    {
        GameObject justCreated = Instantiate(_thePrefab, GetComponent<Transform>().position+Vector3.down*1, Quaternion.identity);
        justCreated.GetComponent<MeshCollider>().convex = true;
        justCreated.tag = "Grabbable"; 
        justCreated.AddComponent<TargetSelect>();
        justCreated.AddComponent<Outline>();
        Rigidbody rb = justCreated.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //Si probleme changer ici
        rb.mass = 1;
        _uniqueId = justCreated.GetInstanceID();
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

    public int getId()
    {
        return _uniqueId;
    }


}
