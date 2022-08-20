using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class EnemyPattern : MonoBehaviour
    {
        IPattern pattern = new PatternSimple();

        int frame = 0;

        // Start is called before the first frame update
        void Start()
        {
            pattern.Init(transform.position);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            pattern.Step(frame, transform.position);

            frame += 1;
        }
    } 
}
