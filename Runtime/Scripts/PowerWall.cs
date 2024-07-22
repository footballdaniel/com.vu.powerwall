using UnityEngine;

public class PowerWall : MonoBehaviour
{
    [SerializeField] bool _activateStereoRendering;
        
    [Header("Dependencies")]
    [SerializeField] GameObject _projectionPlane;
    [SerializeField] XRTracker _motionTracker;
    [SerializeField] StereoCameraController _cameraController;
    [SerializeField] private Persistence _persistence;
    
    public void CalibrateOrigin()
    {
        _calibrationData = new CalibrationData(_motionTracker.Position, _motionTracker.Rotation);
        _persistence.Save(_calibrationData);
        
        Debug.Log(_calibrationData.Rotation.eulerAngles.y);
    }

    void Start()
    {
        _persistence = new Persistence();
        _calibrationData = _persistence.TryLoadCalibration();
        

        
        if (_activateStereoRendering)
            _cameraController.Activate3D();
    }

    void Update()
    {
        AddOffsetToCamera();
        

    }

    void AddOffsetToCamera()
    {
        _cameraController.transform.position = _motionTracker.Position - _calibrationData.Offset;
        _cameraController.transform.rotation = _motionTracker.Rotation * _calibrationData.Rotation;
    }


    #region Gizmos
    void OnDrawGizmos()
    {
        Gizmos.DrawWireMesh(
            _projectionPlane.GetComponent<MeshFilter>().sharedMesh,
            _projectionPlane.transform.position,
            _projectionPlane.transform.rotation,
            _projectionPlane.transform.localScale);
    }
    #endregion
    
    private CalibrationData _calibrationData;
}