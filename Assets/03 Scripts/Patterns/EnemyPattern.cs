using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class EnemyPattern : MonoBehaviour
    {
        IPattern pattern = new PatternBomb();
        IMove move = new MoveApproach(2f, 0f, new Vector3(0f, 0.5f, 50));

        int frame = 0;

        // Start is called before the first frame update
        void Start()
        {
            pattern.Init(transform);
            move.Init(transform);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            pattern.Step(frame, transform);
            move.Step(frame, transform, out bool finish);
            if (finish) Destroy(gameObject);

            frame += 1;
        }
    } 
}
