using System;
using UnityEngine;
using UnityEngine.InputSystem;

// using Valve.VR;

[Serializable]
public class XRTracker : MonoBehaviour 
{
    
    
    [SerializeField] InputActionReference _positionAction;
    [SerializeField] bool _isXForward;

    void OnEnable()
    {
        _positionAction.action.Enable();
    }
    
    void OnDisable()
    {
        _positionAction.action.Disable();
    }

    private void Update()
    {
        var position = _positionAction.action.ReadValue<Vector3>();
        
        if (_isXForward)
            transform.localPosition = new Vector3(position.z, position.y, -position.x);
        else
            transform.localPosition = position;
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
        
        // gizmo in z direction
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}