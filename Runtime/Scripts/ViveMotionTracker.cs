﻿using System;
using UnityEngine;
using Valve.VR;

namespace VROOM.Scripts
{
    [Serializable]
    public class ViveMotionTracker : MonoBehaviour 
    {
        [SerializeField] SteamVR_TrackedObject.EIndex _device = SteamVR_TrackedObject.EIndex.Device1;

        public Vector3 GetPosition() =>  _trackedObject.transform.position;
        
        void Awake() => InstantiateTracker();

        void InstantiateTracker()
        {
            _trackedObject = gameObject.AddComponent<SteamVR_TrackedObject>();
            _trackedObject.index = _device;
        }
        
        SteamVR_TrackedObject _trackedObject;
    }
}