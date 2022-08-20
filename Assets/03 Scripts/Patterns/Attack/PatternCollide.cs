using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class PatternCollide : IPattern
    {
        GameManager gm;

        Transform player_ts;
        ShipHp player_hp;

        float range = 1f;
        float dmg = 3f;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;

            var player = GameObject.FindGameObjectWithTag("Player");
            player_ts = player.transform;
            player_hp = player.GetComponent<ShipHp>();
        }

        public void Step(int frame, Transform transform)
        {
            if((player_ts.position - transform.position).magnitude <= range)
            {
                player_hp.GetDmg(dmg);
            }
        }
    } 
}
