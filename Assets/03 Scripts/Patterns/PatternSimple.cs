using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternSimple : MonoBehaviour, IPattern
    {
        public GameObject game_manager;

        GameObject pref_bullet;

        public void Init(Vector3 origin)
        {
            pref_bullet = game_manager.GetComponent<GameManager>().GetPref(Pref.BulletEnemy);
        }

        public void Step(int frame, Vector3 origin)
        {
            for(var i = 0; i < 3; i++)
            {
                if(frame % (50*6) == i*40)
                {
                    var bullet = Instantiate(pref_bullet);
                    bullet.GetComponent<BulletEnemy>().SetData(5f, -Mathf.PI * 0.5f, 1f);
                }
            }
        }
    } 
}
