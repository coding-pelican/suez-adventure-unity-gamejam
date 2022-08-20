using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class EnemyHp : MonoBehaviour {
        public float hp_max = 100f;
        public float hp;

        public int gold_min;
        public int gold_max;

        private void OnEnable() {
            hp = hp_max;
        }

        public void GetDmg(float _amount) {
            hp -= _amount;
            if (hp <= 0) {
                gameObject.SetActive(false);
                GameManager.Instance.GetGold(Random.Range(gold_min, gold_max + 1));
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
