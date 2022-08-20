using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    class MoveApproach : IMove
    {
        float spd;
        float dir;
        Vector3 ipos;

        float zmin;

        public MoveApproach(float _spd, float _dir, Vector3 _ipos)
        {
            spd = _spd;
            dir = _dir;
            ipos = _ipos;

            zmin = Random.Range(8f, 15f);
        }

        public void Init(Transform transform)
        {
            transform.position = ipos;
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            if (transform.position.z >= zmin)
                transform.position += Vector3.back * spd * Time.fixedDeltaTime;
            finish = false;
        }
    }
}
