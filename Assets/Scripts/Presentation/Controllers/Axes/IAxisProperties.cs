using UnityEngine;

public interface IAxisProperties
{
    Vector3 Direction { get; }
    float Length { get; }
    string Name { get; }
}
