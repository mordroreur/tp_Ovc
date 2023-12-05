using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSelector : MonoBehaviour
{
    private Ray _rayon;
    private RaycastHit _hit;
    private GameObject _hitObject;
    private GameObject _heldObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Lancer du rayon
        _rayon.origin = transform.position;
        _rayon.direction = transform.forward;
        Physics.Raycast(_rayon, out _hit);
        Debug.DrawRay(_rayon.origin, _rayon.direction * 15, Color.red);

        // Décoloration de l'ancien objet
        if (_hitObject != null && (_hit.collider == null || _hit.collider.gameObject != _hitObject))
        {
            if (_hitObject.TryGetComponent(out TargetSelect ts)) ts.Untarget();
        }

        // Recuperation de l'objet touché
        if (_hit.collider)
        {
            _hitObject = _hit.collider.gameObject;
        }
        else
        {
            _hitObject = null;
        }

        // Coloration de l'objet touché
        if (_hitObject != null)
        {
            if (_hitObject.TryGetComponent(out TargetSelect ts)) ts.Target();
        }

        // Affichage du nom de l'objet touché
        /*if (_hitObject) Debug.Log(_hitObject.name);
        else Debug.Log("No object is being hit");
        */
        if(Input.GetButtonDown("Fire1"))
        {
            if (_hitObject.TryGetComponent(out TargetSelect ts))
            {
                ts.Interact(transform);
                _heldObject = _hitObject;
            }
        } else if (Input.GetButtonDown("Fire2"))
        {
            if (_heldObject)
            {
                _heldObject.GetComponent<TargetSelect>().Drop();
                _heldObject = null;
            }
        }
    }
}
