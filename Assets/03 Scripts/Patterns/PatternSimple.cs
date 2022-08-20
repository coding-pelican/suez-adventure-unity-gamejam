using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternSimple : IPattern
    {
        GameManager gm;

        GameObject pref_bullet;

        public void Init(Vector3 origin)
        {
            gm = GameManager.Instance;

            pref_bullet = gm.GetPref(Pref.BulletEnemy);
        }

        public void Step(int frame, Vector3 origin)
        {
            for(var i = 0; i < 3; i++)
            {
                if(frame % (50*6) == i*40)
                {
                    gm.ShotBulletEnemy(origin, 5f, -Mathf.PI*0.5f, 1f);
                }
            }
        }
    } 
}
