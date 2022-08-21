using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class BossHp : MonoBehaviour {
        public float hp_max = 250f;
        public float hp;

        public int gold_min;
        public int gold_max;

        public Transform hp_bar;

        GameManager gm = null;

        private void Awake()
        {
            gm = GameManager.Instance;
        }

        private void OnEnable() {
            hp = hp_max;
        }

        private void FixedUpdate()
        {
            hp_bar.localScale = new Vector3(0.6f * hp / hp_max, 1f, 0.015f);
        }

        public void GetDmg(float _amount) {
            hp -= _amount;
            GameManager.Instance.PlaySfx(3);
            if (hp <= 0)
            {
                gm.AddProgress(9999f);
                gameObject.SetActive(false);
                GameManager.Instance.GetGold(Random.Range(gold_min, gold_max + 1));
                GameManager.Instance.PlaySfx(4);
            }
        }
		
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BulletPlayer"))
            {
                var dmg = other.gameObject.GetComponent<BulletPlayer>().dmg;

                for (int i = 0; i < 8; i++)
                {
                    var item = GameManager.Instance.GetItemBySlot(i);
                    if (item == null) continue;
                    dmg += item.GetDmgBonus();
                }
                for (int i = 0; i < 8; i++)
                {
                    var item = GameManager.Instance.GetItemBySlot(i);
                    if (item == null) continue;
                    dmg *= item.GetDmgMultiply();
                }

                GetDmg(dmg);
                other.gameObject.SetActive(false);
            }
        }
    }
}
