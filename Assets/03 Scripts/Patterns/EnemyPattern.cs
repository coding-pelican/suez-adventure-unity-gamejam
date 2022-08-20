using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class EnemyPattern : MonoBehaviour {
        private GameManager _gm;
        private IPattern pattern = null;
        private IMove move = null;

        private int frame;

        private void Awake() {
            _gm = GameManager.Instance;
        }

        private void OnEnable() {
            pattern = new PatternSimple();
            var _x = Random.Range(-3f, 3f);
            move = new MoveApproach(8f, 0f, new Vector3(_x, 0.5f, 50f));

            pattern.Init(transform);
            move.Init(transform);

            frame = 0;
        }

        private void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            pattern.Step(frame, transform);
            move.Step(frame, transform, out bool finish);
            if (finish) gameObject.SetActive(false);

            frame += 1;
        }
    }
}
