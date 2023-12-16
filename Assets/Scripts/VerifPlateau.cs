using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifPlateau : MonoBehaviour
{
    public BurgerGenAndVerif _verification;
    public ConveyorBelt _conveyorBelt;

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
        if (other.gameObject.name == "plateau(Clone)")
        {
            _verification.VerifyBurger(other.gameObject);
            _conveyorBelt.ConveyorMode(false);
            Destroy(other.gameObject);
        }
    }
}
