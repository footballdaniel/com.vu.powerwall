using UnityEngine;

public class PowerWall : MonoBehaviour
{
    [SerializeField] bool _activateStereoRendering;

    [Header("Dependencies")] [SerializeField] private GameObject _offset;
    [SerializeField] GameObject _projectionPlane;
    [SerializeField] XRTracker _motionTracker;
    [SerializeField] StereoCameraController _cameraController;
    [SerializeField] private Persistence _persistence;
    
    public void CalibrateOrigin()
    {
        // _calibrationData = new CalibrationData(_motionTracker.Position - transform.position, _motionTracker.Rotation);
        // _persistence.Save(_calibrationData);
        
        // subtract offset from camera position
        _offset.transform.localPosition = -_motionTracker.Position - transform.position;
        _offset.transform.localRotation = Quaternion.Inverse(_motionTracker.Rotation);
        _cameraController.transform.SetParent(_offset.transform);
        _cameraController.transform.localRotation = Quaternion.identity;
        _cameraController.transform.localPosition = Vector3.zero;
        // subtract rotation from offset rotation
        // _offset.transform.localRotation = Quaternion.Inverse(_calibrationData.Rotation);



        // Debug.Log(_calibrationData.Rotation.eulerAngles.y);
    }

    void Start()
    {
        _persistence = new Persistence();
        // _calibrationData = _persistence.TryLoadCalibration();
        
        if (_activateStereoRendering)
            _cameraController.Activate3D();
    }

    void Update()
    {
        AddOffsetToCamera();
        
    }

    void AddOffsetToCamera()
    {
        _cameraController.transform.localPosition = _motionTracker.Position;
        //_cameraController.transform.rotation = _motionTracker.Rotation * _calibrationData.Rotation;
    }


    #region Gizmos
    void OnDrawGizmos()
    {
        Gizmos.DrawWireMesh(
            _projectionPlane.GetComponent<MeshFilter>().sharedMesh,
            _projectionPlane.transform.position,
            _projectionPlane.transform.rotation,
            _projectionPlane.transform.localScale);
        
        
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
    #endregion
    
    private CalibrationData _calibrationData;
}