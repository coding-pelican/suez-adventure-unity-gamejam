using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float spd;
    public float dir;

    public float dmg;

    public void SetData(float _spd, float _dir, float _dmg)
    {
        spd = _spd;
        dir = _dir;
        dmg = _dmg;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.right * Mathf.Cos(dir) + Vector3.forward * Mathf.Sin(dir)) * spd * Time.deltaTime;
    }
}
