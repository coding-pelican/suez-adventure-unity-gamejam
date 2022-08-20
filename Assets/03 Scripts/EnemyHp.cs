using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class EnemyHp : MonoBehaviour
    {
        public float hp_max = 100f;
        public float hp;

        // Start is called before the first frame update
        void Start()
        {
            hp = hp_max;
        }

        public void GetDmg(float _amount)
        {
            hp -= _amount;
            if (hp <= 0) Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BulletPlayer"))
            {
                GetDmg(other.gameObject.GetComponent<BulletPlayer>().dmg);
                Destroy(other.gameObject);
            }
        }
    } 
}
