using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class LaserEnemy : MonoBehaviour
    {
        public float time_follow = 2.5f;
        public float time_stop = 1f;
        public float time_shot = 1.5f;

        public float dmg = 10f;
        public float range = 0.3f;

        float time = 0f;

        Transform from;
        Transform target;
        Vector3 lockon;
        ShipHp player_hp;

        LineRenderer lr;

        public void SetData(Transform _from)
        {
            from = _from;
        }

        // Start is called before the first frame update
        void Start()
        {
            lr = GetComponent<LineRenderer>();
            var player = GameObject.FindGameObjectWithTag("Player");
            player_hp = player.GetComponent<ShipHp>();
            target = player.transform;
            lockon = target.position;

            lr.SetPosition(0, from.position);
            lr.SetPosition(1, lockon + Vector3.back * 1f + Vector3.down * 0.5f);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!from.gameObject.activeSelf)
            {
                Destroy(gameObject);
                return;
            }

            time += Time.fixedDeltaTime;

            if (time < time_follow)
            {
                lockon = target.position;
            }
            else if (time < time_follow + time_stop)
            {
                //pass
            }
            else if (time < time_follow + time_stop + time_shot)
            {
                //lr.widthCurve.keys[0].value = Random.Range(0.1f, 1f);
                lr.startWidth = lr.endWidth = Random.Range(0.1f, 1f);
                if ((target.position - lockon).magnitude <= range) player_hp.GetDmg(dmg);
            }
            else Destroy(gameObject);

            lr.SetPosition(0, from.position);
            lr.SetPosition(1, lockon + Vector3.back * 1f + Vector3.down * 0.5f);
        }
    }
}
