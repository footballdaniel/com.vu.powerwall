using Powerwall.Thirdparty;
using UnityEngine;

namespace Powerwall.Runtime
{
    public class PowerwallController : MonoBehaviour
    {
        [SerializeField] ViveMotionTracker _motionTracker;
        [SerializeField] StereoCameraController cameraController;
        [SerializeField] KeyCode _calibrationKey = KeyCode.C;
        [SerializeField] bool Active3D;

        void Update()
        {
            TrackCameraPosition();

            if (Input.GetKeyDown(_calibrationKey))
            {
                if (Active3D)
                    cameraController.Activate3D();
                    
                _calibrationOffset = _motionTracker.GetPosition();
            }
        }

        void TrackCameraPosition() => cameraController.transform.position = _motionTracker.GetPosition() - _calibrationOffset;

        Vector3 _calibrationOffset = Vector3.zero;
    }
}