using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class BulletPlayer : MonoBehaviour {
        GameManager _gm;
        private void Awake() {
            _gm = GameManager.Instance;
        }
        public float spd = 8f;
        public float zmax = 250f;

        public float dmg = 1f;

        void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            transform.position += Vector3.forward * spd * Time.fixedDeltaTime;
            if (transform.position.z >= zmax) Destroy(gameObject);
        }
    }
}
