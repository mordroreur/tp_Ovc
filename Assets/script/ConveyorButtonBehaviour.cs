
using UnityEngine;

public class ConveyorButtonBehaviour : MonoBehaviour, ActivateBehaviour
{
    public ConveyorBelt _conveyorBelt;

    public void Activate()
    {
        _conveyorBelt.ConveyorMode(true);
    }
}
