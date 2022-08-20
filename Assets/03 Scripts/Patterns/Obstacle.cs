using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class Obstacle : MonoBehaviour
    {
        IPattern pattern = null;
        IMove move = null;

        int frame;

        // Start is called before the first frame update
        private void OnEnable()
        {
            pattern = new PatternCollide();
            var _x = Random.Range(-3f, 3f);
            move = new MovePass(6f, 0f, new Vector3(_x, 0.5f, 50f));

            pattern.Init(transform);
            move.Init(transform);

            frame = 0;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            pattern.Step(frame, transform);
            move.Step(frame, transform, out bool finish);
            if (finish) gameObject.SetActive(false);

            frame += 1;
        }
    }
}
