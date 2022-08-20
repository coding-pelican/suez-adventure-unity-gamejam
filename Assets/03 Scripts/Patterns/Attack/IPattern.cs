using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern
{
    public abstract void Init(Transform transform);
    public abstract void Step(int frame, Transform transform);
}
