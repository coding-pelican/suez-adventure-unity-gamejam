using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class BulletPlayerHoming : BulletPlayer
    {
        Transform target;

        private void OnEnable()
        {
            var elist = GameObject.FindGameObjectsWithTag("Enemy");
            if(elist.Length <= 0)
            {
                Destroy(gameObject);
                return;
            }
            var min = 9999f;
            int ind = 0;
            for (var i = 0; i < elist.Length; i++)
            {
                var dist = (elist[i].transform.position - transform.position).magnitude;
                if (dist < min)
                {
                    min = dist;
                    ind = i;
                }
            }
            target = elist[ind].transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(target == null || !target.gameObject.activeSelf)
            {
                OnEnable();
            }
            else
            {
                transform.position += (target.position - transform.position).normalized * spd * Time.fixedDeltaTime;
                if (transform.position.z >= zmax) Destroy(gameObject);
            }
        }
    } 
}
