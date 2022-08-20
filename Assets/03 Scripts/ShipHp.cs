using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class ShipHp : MonoBehaviour {
        GameManager _gm = null;

        public float invi_time_max = 0.5f;
        float invi_time;
        bool invi;

        float GetDef()
        {
            float s = 0f;

            for (int i = 0; i < 8; i++) {
                var item = GameManager.Instance.GetItemBySlot(i);
                if (item == null) continue;
                s += item.GetDefBonus();
            }
            return s;
        }

        private void Awake() {
            _gm = GameManager.Instance;
        }

        private void Start() {
            invi = false;
            invi_time = 0;
        }

        private void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            if (invi_time > 0) {
                invi_time -= Time.fixedDeltaTime;
                if (invi_time <= 0) {
                    invi_time = 0f;
                    invi = false;
                }
            }

            if(_gm.Stages[0] != EStageFlow.L3)
                _gm.AddProgress(Time.fixedDeltaTime);

            //Debug.Log(invi_time.ToString());
        }

        public void GetDmg(float amount) {
            if (invi == false) {
                _gm.ReduceHp(amount * Mathf.Max(1f - GetDef() * 0.01f, 0.2f));

                invi = true;
                invi_time = invi_time_max;

                //Debug.Log("Hit! Hp:" + hp.ToString());

                _gm.PlaySfx(0);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("BulletEnemy")) {
                GetDmg(other.gameObject.GetComponent<BulletEnemy>().dmg);
                Destroy(other.gameObject);
            }
        }
    }
}
