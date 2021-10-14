using UnityEngine;

namespace Scripts
{
    public class PowerwallController : MonoBehaviour
    {
        [SerializeField] bool _active3D;
        [SerializeField] GameObject _projectionPlane;
        [SerializeField] ViveMotionTracker _motionTracker;
        [SerializeField] StereoCameraController _cameraController;

        /// <summary>
        /// Place the motion tracker at the bottom center of the projection plane and call the method to calibrate
        /// </summary>
        public void CalibrateOrigin() => _calibrationOffset = _motionTracker.GetPosition();
        
        void Update()
        {
            TrackCameraPosition();

            if (_active3D)
                _cameraController.Activate3D();
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireMesh(
                _projectionPlane.GetComponent<MeshFilter>().sharedMesh,
                _projectionPlane.transform.position,
                _projectionPlane.transform.rotation,
                _projectionPlane.transform.localScale);
        }

        void TrackCameraPosition() => _cameraController.transform.position = _motionTracker.GetPosition() - _calibrationOffset;

        Vector3 _calibrationOffset = Vector3.zero;
    }
}