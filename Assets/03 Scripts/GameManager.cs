using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public enum Pref {
        BulletPlayer,
        BulletEnemy,
    }

    public class GameManager : Singleton<GameManager> {
        public GameObject prefab_bullet_player;
        public GameObject prefab_bullet_enemy;

        Dictionary<Pref, GameObject> dict = new();

        protected override void Awake() {
            base.Awake();
            dict.Add(Pref.BulletPlayer, prefab_bullet_player);
            dict.Add(Pref.BulletEnemy, prefab_bullet_enemy);
        }

        public GameObject GetPref(Pref enum_pref) {
            if (dict.TryGetValue(enum_pref, out GameObject pref)) return pref;
            return null;
        }
    }
}