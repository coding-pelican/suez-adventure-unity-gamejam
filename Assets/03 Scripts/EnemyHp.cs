using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class EnemyHp : MonoBehaviour
    {
        public float hp_max = 100f;
        public float hp;

        public int gold_min;
        public int gold_max;

        private void OnEnable()
        {
            hp = hp_max;
        }

        public void GetDmg(float _amount)
        {
            hp -= _amount;
            if (hp <= 0)
            {
                gameObject.SetActive(false);
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + Random.Range(gold_min, gold_max + 1));
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BulletPlayer"))
            {
                GetDmg(other.gameObject.GetComponent<BulletPlayer>().dmg);
                other.gameObject.SetActive(false);
            }
        }
    } 
}
