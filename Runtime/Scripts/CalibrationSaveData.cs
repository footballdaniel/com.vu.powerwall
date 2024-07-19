using System;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class CalibrationSaveData
{
    public Location Location;

    public CalibrationSaveData(Vector3 position) => Location = new Location(position);
        
}

[Serializable]
public class Location
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;
        
        
    [JsonIgnore]
    public Vector2 OnGround => new Vector2(X, Z);

    [JsonConstructor]
    public Location(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Location(Vector3 values)
    {
        X = values.x;
        Y = values.y;
        Z = values.z;
    }

    public static implicit operator Vector3(Location location)
        => new Vector3(location.X, location.Y, location.Z);
}