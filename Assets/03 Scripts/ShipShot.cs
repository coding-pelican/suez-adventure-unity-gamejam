using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class ShipShot : MonoBehaviour {
        private GameManager _gm;

        public float cooltime_max = 0.25f;
        float cooltime;

        private void Awake() {
            _gm = GameManager.Instance;
        }

        void Start() {
            cooltime = cooltime_max;
        }

        void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            cooltime -= Time.fixedDeltaTime;
            if (cooltime <= 0f) {
                var bullet = Instantiate(_gm.GetPref(Pref.BulletPlayer));
                bullet.transform.position = transform.position;

                cooltime += cooltime_max;
            }
        }
    }
}
