using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternRadiation : IPattern
    {
        GameManager gm;

        Transform player_ts;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;

            player_ts = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void Step(int frame, Transform transform)
        {
            if(frame % (50*4) == 100)
            {
                var dir = Vector3.Angle(Vector3.right, player_ts.position - transform.position) * -Mathf.Deg2Rad;
                for (int i = 0; i < 3; i++)
                {
                    gm.ShotBulletEnemy(transform.position, 5f+ Random.Range(-2f, 2f), dir + Random.Range(-0.3f, 0.3f), 1f);
                }
            }
        }
    } 
}
