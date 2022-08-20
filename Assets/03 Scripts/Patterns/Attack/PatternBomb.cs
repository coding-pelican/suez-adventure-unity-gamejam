using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternBomb : IPattern
    {
        GameManager gm;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;
        }

        public void Step(int frame, Transform transform)
        {
            if (frame == 50 * 7)
            {
                for (int i = 0; i < 100; i++)
                {
                    gm.ShotBulletEnemy(transform.position, 13f, -Mathf.PI * i / 100f, 10f);
                }
            }
        }
    }
}
