using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class LaserBoss : MonoBehaviour
    {
        public float time_stop = 1.5f;
        public float time_shot = 1.5f;

        public float dmg = 30f;
        public float range = 0.3f;

        float time = 0f;

        Vector3 from;
        Transform target;
        Vector3 lockon;
        ShipHp player_hp;

        LineRenderer lr;

        public void SetData(Vector3 _from, Vector3 _to)
        {
            from = _from;
            lockon = _to;
        }

        // Start is called before the first frame update
        void Start()
        {
            lr = GetComponent<LineRenderer>();
            var player = GameObject.FindGameObjectWithTag("Player");
            player_hp = player.GetComponent<ShipHp>();
            target = player.transform;

            lr.SetPosition(0, from);
            lr.SetPosition(1, lockon + Vector3.back * 3f + Vector3.down * 0.5f);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            time += Time.fixedDeltaTime;

            if (time < time_stop)
            {
                //pass
            }
            else if (time < time_stop + time_shot)
            {
                //lr.widthCurve.keys[0].value = Random.Range(0.1f, 1f);
                lr.startWidth = lr.endWidth = Random.Range(0.1f, 2f);
                if ((target.position - lockon).magnitude <= range) player_hp.GetDmg(dmg);
            }
            else Destroy(gameObject);

            lr.SetPosition(0, from);
            lr.SetPosition(1, lockon + Vector3.back * 3f + Vector3.down * 0.5f);
        }
    }
}
