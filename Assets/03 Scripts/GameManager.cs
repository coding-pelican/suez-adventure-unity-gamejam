using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public enum Pref
    {
        BulletPlayer,
        BulletEnemy,
    }

    public class GameManager : MonoBehaviour
    {
        public GameObject prefab_bullet_player;
        public GameObject prefab_bullet_enemy;

        Dictionary<Pref, GameObject> dict = new();

        private void Awake()
        {
            dict.Add(Pref.BulletPlayer, prefab_bullet_player);
            dict.Add(Pref.BulletEnemy, prefab_bullet_enemy);
        }

        public GameObject GetPref(Pref enum_pref)
        {
            GameObject pref;
            if (dict.TryGetValue(enum_pref, out pref)) return pref;
            return null;
        }
    }
}