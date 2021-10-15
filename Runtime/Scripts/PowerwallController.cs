using System;
using UnityEngine;

namespace Scripts
{
    public class PowerwallController : MonoBehaviour
    {
        [SerializeField] bool _active3D;
        [SerializeField] GameObject _projectionPlane;
        [SerializeField] ViveMotionTracker _motionTracker;
        [SerializeField] StereoCameraController _cameraController;

        void Awake()
        {
            if (CanLoadExistingCalibration())
                LoadCalibration();
        }

        void LoadCalibration()
        {
            
        }

        bool CanLoadExistingCalibration() => PlayerPrefs.HasKey("CalibrationOffsetPowerwall");


        /// <summary>
        /// Place the motion tracker at the bottom center of the projection plane and call the method to calibrate
        /// </summary>
        public void CalibrateOrigin() => _calibrationOffset = _motionTracker.GetPosition();

        void Update()
        {
            AddOffsetToCamera();

            if (_active3D)
                _cameraController.Activate3D();
        }

        void AddOffsetToCamera() =>
            _cameraController.transform.position = _motionTracker.GetPosition() - _calibrationOffset;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireMesh(
                _projectionPlane.GetComponent<MeshFilter>().sharedMesh,
                _projectionPlane.transform.position,
                _projectionPlane.transform.rotation,
                _projectionPlane.transform.localScale);
        }

        Vector3 _calibrationOffset = Vector3.zero;
    }
}