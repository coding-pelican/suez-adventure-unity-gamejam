using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern
{
    public abstract void Init(Vector3 origin);
    public abstract void Step(int frame, Vector3 origin);
}
