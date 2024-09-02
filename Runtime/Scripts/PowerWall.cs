using UnityEngine;

public class PowerWall : MonoBehaviour
{
    [SerializeField] bool _activateStereoRendering;

    [Header("Settings"), SerializeField] private Vector2 _worldPosition;
    [SerializeField] private float _worldRotationAngle;
    
    [Header("Dependencies"), SerializeField] GameObject _projectionPlane;
    // [SerializeField] private Persistence _persistence;
    
    public void CalibrateOrigin()
    {
        // _calibrationData = new CalibrationData(_motionTracker.Position - transform.position, _motionTracker.Rotation);
        // _persistence.Save(_calibrationData);
        
        // subtract offset from camera position
        // subtract rotation from offset rotation
        // _offset.transform.localRotation = Quaternion.Inverse(_calibrationData.Rotation);



        // Debug.Log(_calibrationData.Rotation.eulerAngles.y);
    }

    void Start()
    {
        // _persistence = new Persistence();
        // _calibrationData = _persistence.TryLoadCalibration();
        

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