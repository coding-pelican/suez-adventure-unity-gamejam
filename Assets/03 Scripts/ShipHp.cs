using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class ShipHp : MonoBehaviour
    {
        GameManager gm = null;

        public float invi_time_max = 0.5f;
        float invi_time;
        bool invi;

        float GetDef()
        {
            float s = 0f;

            for (int i = 0; i < 8; i++)
            {
                var item = GameManager.Instance.GetItemBySlot(i);
                if (item == null) continue;
                s += item.GetDefBonus();
            }
            return s;
        }

        // Start is called before the first frame update
        void Start()
        {
            gm = GameManager.Instance;

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

            //Debug.Log(invi_time.ToString());
        }

        public void GetDmg(float amount)
        {
            if (invi == false)
            {
                gm.ReduceHp( amount * Mathf.Max(1f - GetDef() * 0.01f, 0.2f) );

                invi = true;
                invi_time = invi_time_max;

                //Debug.Log("Hit! Hp:" + hp.ToString());
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
