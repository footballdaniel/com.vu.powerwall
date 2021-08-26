using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoCamera: MonoBehaviour
{
    [SerializeField] private bool _isActive3D = false;
    [SerializeField] private Camera _cameraLeft;
    [SerializeField] private Camera _cameraRight;


    void Awake()
    {
        Time.captureFramerate = 120;
        Application.targetFrameRate = 120;
    }


    void FixedUpdate()
    {
        if (_isActive3D)
        {
            SwitchBetweenCameras();
        }
    }

    private void SwitchBetweenCameras()
    {
        if (_isActiveRightEye)
        {
            _cameraLeft.Render();
            _cameraLeft.enabled = true;
            _cameraRight.enabled = false;
            _isActiveRightEye = false;
        }
        else
        {
            _cameraRight.Render();
            _cameraRight.enabled = true;
            _cameraLeft.enabled = false;
            _isActiveRightEye = true;
        }
    }

    bool _isActiveRightEye = false;
}