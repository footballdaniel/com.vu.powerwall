using UnityEngine;

namespace Scripts
{
    public class StereoCameraController : MonoBehaviour
    {
        [SerializeField] Camera _cameraLeft;
        [SerializeField] Camera _cameraRight;
    
        void Awake() => Application.targetFrameRate = 120;

        void FixedUpdate()
        {
            if (_active3D)
                SwitchBetweenCameras();
        }

        public void Activate3D() => _active3D = true;

        void SwitchBetweenCameras()
        {
            if (_displayLeftEyeImage)
            {
                _cameraLeft.Render();
                _cameraLeft.enabled = true;
                _cameraRight.enabled = false;
                _displayLeftEyeImage = false;
            }
            else
            {
                _cameraRight.Render();
                _cameraRight.enabled = true;
                _cameraLeft.enabled = false;
                _displayLeftEyeImage = true;
            }
        }

        bool _active3D;
        bool _displayLeftEyeImage;
    }
}