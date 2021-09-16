using System;
using UnityEngine;

namespace Powerwall.Thirdparty
{
    [Serializable]
    public class ViveMotionTracker : MotionTracker
    {
        [SerializeField] SteamVR_TrackedObject _trackedObject;
        [SerializeField] GameObject _viveTrackedObject;
        [SerializeField] SteamVR_TrackedObject.EIndex _device = SteamVR_TrackedObject.EIndex.Device1;
        
        void Awake() => InstantiateTracker();

        void InstantiateTracker()
        {
            _trackedObject = gameObject.AddComponent<SteamVR_TrackedObject>();
            _trackedObject.index = _device;
        }

        public override Vector3 GetPosition() =>  _viveTrackedObject.transform.position;
    }
}