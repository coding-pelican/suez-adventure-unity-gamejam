using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class ShipHp : MonoBehaviour
    {
        public float hp_max = 10f;
        public float hp;

        public float invi_time_max = 0.5f;
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
                invi_time -= Time.fixedDeltaTime;
                if (invi_time <= 0)
                {
                    invi_time = 0f;
                    invi = false;
                }
            }

            Debug.Log(invi_time.ToString());
        }

        public void GetDmg(float amount)
        {
            if (invi == false)
            {
                hp -= amount;
                if (hp <= 0) Debug.Log("Game Over");

                invi = true;
                invi_time = invi_time_max;

                Debug.Log("Hit! Hp:" + hp.ToString());
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
}
