using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    public abstract void Init(Transform transform);
    public abstract void Step(int frame, Transform transform, out bool finish);
}