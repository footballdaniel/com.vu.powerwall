using System;
using UnityEngine;

namespace Powerwall.Thirdparty
{
    [Serializable]
    public class ViveMotionTracker : MotionTracker
    {
        [SerializeField] private SteamVR_TrackedObject _trackedObject;
        [SerializeField] private GameObject _viveTrackedObject;

        private void Awake()
        {
            InstantiateTracker();
        }

        private void InstantiateTracker()
        {
            _trackedObject = gameObject.AddComponent<SteamVR_TrackedObject>();
            _trackedObject.index = SteamVR_TrackedObject.EIndex.Device1;
        }


        public override Vector3 GetPosition()
        {
            return _viveTrackedObject.transform.position;
        }
    }
}