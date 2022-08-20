using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    [System.Serializable]
    public class EnemyList {
        public List<GameObject> enemy = new();
    }

    public class EnemySpawner : MonoBehaviour {
        private GameManager _gm;
        private List<EnemyList> _enemyPool = new();
        private int _enemyTypeCnt;

        public GameObject[] enemyType;
        public int objCnt;
        public float spawningTimeRate = 4.6f;
        public bool isSpawningTimeRandom = false;
        public float minSpawningTime = 3.6f;
        public float maxSpawningTime = 5.6f;

        private void Awake() {
            _gm = GameManager.Instance;
            _gm.EnemySpawner = this;
        }

        private void Start() {
            _enemyTypeCnt = enemyType.Length;
            if (_enemyPool.Count > 0) {
                _enemyPool.Clear();
            }
            for (int type = 0; type < _enemyTypeCnt; type++) {
                EnemyList enemies = new();
                for (int idx = 0; idx < objCnt; idx++) {
                    enemies.enemy.Add(CreateObj(enemyType[type], transform));
                }
                _enemyPool.Add(enemies);
            }
        }

        public void SStart()
        {
            Start();
        }

        private IEnumerator ActivateMob() {
            yield return new WaitForSeconds(0.5f);

            while (_gm.IsCurGameFlowField()) {
                int random = Random.Range(0, _enemyPool.Count); //사실 -1 하면 안됨
                _enemyPool[random].enemy[GetSpawnableMob(_enemyPool[random].enemy)].SetActive(true);

                yield return new WaitForSeconds(isSpawningTimeRandom ? Random.Range(minSpawningTime, maxSpawningTime) : spawningTimeRate);
            }
        }

        private int GetSpawnableMob(List<GameObject> mobs) {
            List<int> num = new();
            for (int i = 0; i < objCnt; i++) {
                if (!mobs[i].activeSelf) {
                    num.Add(i);
                }
            }
            return num.Count > 0 ? Random.Range(0, num.Count) : 0;
        }

        private GameObject CreateObj(GameObject obj, Transform parent) {
            GameObject copy = Instantiate(obj);
            copy.transform.SetParent(parent);
            copy.SetActive(false);
            return copy;
        }

        public void PlayGame() {
            if (_gm.IsCurGameFlowField()) {
                for (int type = 0; type < _enemyPool.Count; type++) {
                    for (int idx = 0; idx < _enemyPool[type].enemy.Count; idx++) {
                        if (_enemyPool[type].enemy[idx].activeSelf) {
                            _enemyPool[type].enemy[idx].SetActive(false);
                        }
                    }
                }
                StartCoroutine(ActivateMob());
            } else {
                StopAllCoroutines();
            }
        }
        public void DeactivateActiveMobs() {
            for (int type = 0; type < _enemyPool.Count; type++) {
                for (int idx = 0; idx < _enemyPool[type].enemy.Count; idx++) {
                    if (_enemyPool[type].enemy[idx].activeSelf) {
                        _enemyPool[type].enemy[idx].SetActive(false);
                    }
                }
            }
        }
    }
}