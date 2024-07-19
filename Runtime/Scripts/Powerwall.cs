using UnityEngine;

public class Powerwall : MonoBehaviour
{
    [SerializeField] bool _active3D;
        
    [Header("Dependencies")]
    [SerializeField] GameObject _projectionPlane;
    [SerializeField] ViveMotionTracker _motionTracker;
    [SerializeField] StereoCameraController _cameraController;
        
    [Header("Persistent")]
    [SerializeField] SaveFile _saveFile;
        

    /// <summary>
    /// Place the motion tracker at the bottom center of the projection plane and call the method to calibrate
    /// </summary>
    public void CalibrateOrigin()
    {
        _calibrationOffset = _motionTracker.GetPosition();
        _saveFile.Save(new CalibrationSaveData(_calibrationOffset));
    }

    void Start() => _calibrationOffset = _saveFile.TryLoadCalibration();

    void Update()
    {
        AddOffsetToCamera();

        if (_active3D)
            _cameraController.Activate3D();
    }

    void AddOffsetToCamera() =>
        _cameraController.transform.position = _motionTracker.GetPosition() - _calibrationOffset;

    #region Gizmos
    void OnDrawGizmos()
    {
        Gizmos.DrawWireMesh(
            _projectionPlane.GetComponent<MeshFilter>().sharedMesh,
            _projectionPlane.transform.position,
            _projectionPlane.transform.rotation,
            _projectionPlane.transform.localScale);
        
        Debug.LogError(" test");
    }
    
    
    #endregion

    Vector3 _calibrationOffset = Vector3.zero;
}