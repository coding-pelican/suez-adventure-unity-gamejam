using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Suez
{
    public class ShipShot : MonoBehaviour
    {
        GameManager gm;

        public float cooltime_max = 0.25f;
        float cooltime;

        // Start is called before the first frame update
        void Start()
        {
            cooltime = cooltime_max;

            gm = GameManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            cooltime -= Time.deltaTime;
            if (cooltime <= 0f)
            {
                var bullet = Instantiate(gm.GetPref(Pref.BulletPlayer));
                bullet.transform.position = transform.position;

                cooltime += cooltime_max;
            }
        }
    }
}
