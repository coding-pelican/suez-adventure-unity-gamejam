using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHp : MonoBehaviour
{
    public float hp_max = 10f;
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = hp_max;
    }

    void GetDmg(float amount)
    {
        hp -= amount;
        if (hp <= 0) Debug.Log("Game Over");
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
