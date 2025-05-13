using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public event Action<float> DirectionChanged;

    protected void OnDirectionChanged(float direction)
    {
        DirectionChanged?.Invoke(direction);
    }
}
