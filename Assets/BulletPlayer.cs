using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float spd = 8f;
    public float zmax = 250f;

    public float dmg = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.forward * spd * Time.deltaTime;
        if (transform.position.z >= zmax) Destroy(gameObject);
    }
}