using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternSimple : IPattern
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
            for(var i = 0; i < 3; i++)
            {
                if(frame % (50*6) == i*40)
                {
                    gm.ShotBulletEnemy(transform.position, 5f, Vector3.Angle(Vector3.right, player_ts.position - transform.position) *-Mathf.Deg2Rad, 1f);
                }
            }
        }
    } 
}
