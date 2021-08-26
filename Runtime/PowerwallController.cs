using UnityEngine;

namespace Powerwall.Runtime
{
    public class PowerwallController : MonoBehaviour
    {
        [SerializeField] private MotionTracker _motionTracker;
        [SerializeField] private StereoCamera _camera;
        [SerializeField] private KeyCode _calibrationKey = KeyCode.C;

        void Update()
        {
            _camera.transform.position = _motionTracker.GetPosition() - _calibrationOffset;

            if (Input.GetKeyDown(_calibrationKey))
            {
                _calibrationOffset = _motionTracker.GetPosition();
            }
        }

        Vector3 _calibrationOffset = Vector3.zero;
    }
}