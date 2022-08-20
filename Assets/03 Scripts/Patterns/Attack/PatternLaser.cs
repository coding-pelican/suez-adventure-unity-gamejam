using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternLaser : IPattern
    {
        GameManager gm;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;
        }

        public void Step(int frame, Transform transform)
        {
            for(var i = 0; i < 3; i++)
            {
                if(frame % (50*6) == 150)
                {
                    gm.ShotLaserEnemy(transform);
                }
            }
        }
    } 
}
