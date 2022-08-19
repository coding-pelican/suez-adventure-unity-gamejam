using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHp : MonoBehaviour
{
    public float hp_max = 10f;
    public float hp;

    public float invi_time_max;
    float invi_time;
    bool invi;

    // Start is called before the first frame update
    void Start()
    {
        hp = hp_max;
        invi = false;
        invi_time = 0;
    }

    private void FixedUpdate()
    {
        if (invi_time > 0)
        {
            invi_time -= Time.deltaTime;
            if(invi_time <= 0)
            {
                invi_time = 0f;
                invi = false;
            }
        }
    }

    void GetDmg(float amount)
    {
        if (invi == false)
        {
            hp -= amount;
            if (hp <= 0) Debug.Log("Game Over");

            invi = true;
            invi_time = invi_time_max;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            GetDmg(other.gameObject.GetComponent<BulletEnemy>().dmg);
            Destroy(other.gameObject);
        }
    }
}
