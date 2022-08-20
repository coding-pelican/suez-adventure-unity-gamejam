using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Suez {
    public class GameManager : Singleton<GameManager> {

        PrefabManagerGame prefab_manager;

        /*protected override void Awake() {
            base.Awake();
            dict.Add(Pref.BulletPlayer, prefab_bullet_player);
            dict.Add(Pref.BulletEnemy, prefab_bullet_enemy);
        }*/
        void OnEnable()
        {
            // 씬 매니저의 sceneLoaded에 체인을 건다.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);

            prefab_manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManagerGame>();
        }

        public GameObject GetPref(Pref enum_pref) {
            return prefab_manager.GetPref(enum_pref);
        }

        public void ShotBulletEnemy(Vector3 pos, float spd, float dir, float dmg)
        {
            var bullet = Instantiate(GetPref(Pref.BulletEnemy));
            bullet.transform.position = pos;
            bullet.GetComponent<BulletEnemy>().SetData(spd, dir, dmg);
        }

        public void ShotLaserEnemy(Transform from)
        {
            var laser = Instantiate(GetPref(Pref.LaserEnemy));
            laser.GetComponent<LaserEnemy>().SetData(from);
        }
    }
}
