using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class ShipShot : MonoBehaviour {
        private GameManager _gm;

        public float cooltime_max = 0.25f;
        float cooltime;
        float bonus_cooltime_max = 3f;
        float bonus_cooltime = 3f;

		
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

            int num = 0;
            for (int i = 0; i < 8; i++)
            {
                var item = GameManager.Instance.GetItemBySlot(i);
                if (item == null) continue;
                num += item.GetHomingNum();
            }

            if (num == 0) return;

            bonus_cooltime -= Time.fixedDeltaTime;
            if (bonus_cooltime <= 0f)
            {
                var bullet = Instantiate(_gm.GetPref(Pref.BulletPlayerHoming));
                bullet.transform.position = transform.position;

                bonus_cooltime += bonus_cooltime_max/num;
            }
        }
    }
}
