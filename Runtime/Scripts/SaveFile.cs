using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class SaveFile : MonoBehaviour
{
    [SerializeField] string _filename = "calibration_data.json";

    public bool CanLoad => File.Exists(_path);

    void Awake() => _path = Path.Combine(Application.persistentDataPath, _filename);

    public Vector3 TryLoadCalibration()
    {
        if (!File.Exists(_path))
            return Vector3.zero;

        var streamReader = new StreamReader(_path);
        var json = streamReader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<CalibrationSaveData>(json);
        return data.Location;
    }

    public void Save(CalibrationSaveData saveData)
    {
        var serializedData = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(_path, serializedData);
    }

    #region ContextMenu

    [ContextMenu("Trigger Save with empty data")]
    public void SaveEmptyData()
    {
        var _emptyData = new CalibrationSaveData(Vector3.one);
        Save(_emptyData);
    }

    [ContextMenu(("Show path"))]
    void ShowPath() => Debug.Log(Application.persistentDataPath);

    #endregion

    string _path;
}