using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    class MovePass : IMove
    {
        float spd;
        float dir;
        Vector3 ipos;

        public MovePass(float _spd, float _dir, Vector3 _ipos)
        {
            spd = _spd;
            dir = _dir;
            ipos = _ipos;
        }

        public void Init(Transform transform)
        {
            transform.position = ipos;
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            transform.position += Vector3.back * spd * Time.fixedDeltaTime;
            if (transform.position.z <= -10f) finish = true;
            else finish = false;
        }
    }
}
