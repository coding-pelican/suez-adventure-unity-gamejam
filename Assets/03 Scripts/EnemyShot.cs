using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class EnemyShot : MonoBehaviour
    {
        public GameObject prefab_bullet;
        public float spd = 7f;
        public float dmg = 1f;

        public float cooltime_max = 0.25f;
        float cooltime;

        // Start is called before the first frame update
        void Start()
        {
            cooltime = cooltime_max;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            cooltime -= Time.fixedDeltaTime;

            if (cooltime <= 0f)
            {
                var bullet = Instantiate(prefab_bullet);
                bullet.transform.position = transform.position;
                bullet.GetComponent<BulletEnemy>().SetData(spd, Random.Range(-Mathf.PI, 0f), dmg);

                cooltime += cooltime_max;
            }
        }
    } 
}
