using System;
using UnityEngine;
using UnityEngine.InputSystem;

// using Valve.VR;

[Serializable]
public class XRTracker : MonoBehaviour 
{
    public Vector3 Position => transform.position;
    
    [SerializeField] InputActionReference _positionAction;
    

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
        transform.position = _positionAction.action.ReadValue<Vector3>();
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
        
        // gizmo in z direction
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up);
    }
    
    


    // // [SerializeField] SteamVR_TrackedObject.EIndex _device = SteamVR_TrackedObject.EIndex.Device1;
    //
    // public Vector3 GetPosition() =>  _trackedObject.transform.position;
    //     
    // void Awake() => InstantiateTracker();
    //
    // void InstantiateTracker()
    // {
    //     _trackedObject = gameObject.AddComponent<SteamVR_TrackedObject>();
    //     _trackedObject.index = _device;
    // }
    //     
    // SteamVR_TrackedObject _trackedObject;
}