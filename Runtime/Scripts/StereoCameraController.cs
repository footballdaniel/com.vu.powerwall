using UnityEngine;

public class StereoCameraController : MonoBehaviour
{
    [SerializeField] XRTracker _motionTracker;
    
    [SerializeField] Camera _cameraLeft;
    [SerializeField] Camera _cameraRight;
    
    void Awake() => Application.targetFrameRate = 120;

    private void Start()
    {
        transform.SetParent(_motionTracker.transform);
        transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (_active3D)
            SwitchBetweenCameras();
    }
    
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