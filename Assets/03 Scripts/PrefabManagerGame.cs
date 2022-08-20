using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public enum Pref
    {
        BulletPlayer,
        BulletPlayerHoming,
        BulletEnemy,
        LaserEnemy,
    }

    public class PrefabManagerGame : MonoBehaviour
    {
        public GameObject prefab_bullet_player;
        public GameObject prefab_bullet_player_homing;
        public GameObject prefab_bullet_enemy;
        public GameObject prefab_laser_enemy;

        Dictionary<Pref, GameObject> dict = new();

        private void Awake()
        {
            dict.Add(Pref.BulletPlayer, prefab_bullet_player);
            dict.Add(Pref.BulletPlayerHoming, prefab_bullet_player_homing);
            dict.Add(Pref.BulletEnemy, prefab_bullet_enemy);
            dict.Add(Pref.LaserEnemy, prefab_laser_enemy);
        }

        public GameObject GetPref(Pref enum_pref)
        {
            if (dict.TryGetValue(enum_pref, out GameObject pref)) return pref;
            return null;
        }
    } 
}
