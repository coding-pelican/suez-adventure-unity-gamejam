using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShot : MonoBehaviour
{
    public GameObject prefab_bullet;

    public float cooltime_max = 0.25f;
    float cooltime;

    // Start is called before the first frame update
    void Start()
    {
        cooltime = cooltime_max;
    }

    // Update is called once per frame
    void Update()
    {
        cooltime -= Time.deltaTime;
        if(cooltime <= 0f)
        {
            var bullet = Instantiate(prefab_bullet);
            bullet.transform.position = transform.position;

            cooltime += cooltime_max;
        }
    }
}
