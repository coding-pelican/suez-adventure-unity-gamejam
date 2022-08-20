using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Suez {
    public enum EGameFlow {
        MainMenu,
        Field,
        Shop,
        GameOver,
        GameEnding
    }

    public enum EStageFlow {
        NotStart,
        L1,
        L2,
        L3,
        Clear
    }

    public class GameManager : Singleton<GameManager> {
        private PrefabManagerGame prefab_manager;
        private GameObject player;
        private SpriteManager sprite_manager;
        private ItemManager item_manager;
        private EnemySpawner _enemySpawner;
        private float playerXInput;
        private EGameFlow _curGameFlow;
        private List<EStageFlow> _stages = new();

        public float PlayerXInput { get => playerXInput; set => playerXInput = value; }
        public EGameFlow CurGameFlow { get => _curGameFlow; set => _curGameFlow = value; }
        public List<EStageFlow> Stages { get => _stages; set => _stages = value; }
        public EnemySpawner EnemySpawner { get => _enemySpawner; set => _enemySpawner = value; }

        /*protected override void Awake() {
            base.Awake();
            dict.Add(Pref.BulletPlayer, prefab_bullet_player);
            dict.Add(Pref.BulletEnemy, prefab_bullet_enemy);
        }*/
        protected override void Awake() {
            base.Awake();
            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetFloat("Hp", 80f);
            PlayerPrefs.SetFloat("HpMax", 80f);
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("Slot0", -1);
            PlayerPrefs.SetInt("Slot1", -1);
            PlayerPrefs.SetInt("Slot2", -1);
            PlayerPrefs.SetInt("Slot3", -1);
            PlayerPrefs.SetInt("Slot4", -1);
            PlayerPrefs.SetInt("Slot5", -1);
            PlayerPrefs.SetInt("Slot6", -1);
            PlayerPrefs.SetInt("Slot7", -1);

            InitAwake();
        }

        private void OnEnable() {
            // 씬 매니저의 sceneLoaded에 체인을 건다.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }

        private void InitAwake() {
            prefab_manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManagerGame>();
            sprite_manager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<SpriteManager>();
            item_manager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerXInput = player.GetComponent<ShipMove>().XInput;
            InitStage();
        }

        private void InitStage() {
            if (Stages.Count > 0) Stages.Clear();
            CurGameFlow = EGameFlow.MainMenu;

            EStageFlow stage1 = EStageFlow.NotStart;
            EStageFlow stage2 = EStageFlow.NotStart;
            EStageFlow stage3 = EStageFlow.NotStart;

            Stages.Add(stage1);
            Stages.Add(stage2);
            Stages.Add(stage3);
        }

        public void PlayGame() => EnemySpawner.PlayGame();

        public bool IsCurGameFlowField() => CurGameFlow.Equals(EGameFlow.Field);

        public GameObject GetPref(Pref enum_pref) {
            return prefab_manager.GetPref(enum_pref);
        }

        public Sprite GetSpr(int index) {
            return sprite_manager.GetSpr(index);
        }

        public ItemBase GetItem(int index) {
            return item_manager.GetItem(index);
        }
        public ItemBase GetItemBySlot(int slot) {
            return item_manager.GetItem(PlayerPrefs.GetInt("Slot" + slot.ToString()));
        }

        public GameObject GetPlayer() {
            return player;
        }

        public void ReduceHp(float amount) {
            var hp_new = PlayerPrefs.GetFloat("Hp") - amount;
            PlayerPrefs.SetFloat("Hp", Mathf.Max(0f, hp_new));
        }

        public void IncreaseHp(float amount) {
            var hp_max = PlayerPrefs.GetFloat("HpMax");
            var hp_new = PlayerPrefs.GetFloat("Hp") + amount;
            PlayerPrefs.SetFloat("Hp", Mathf.Min(hp_new, hp_max));
        }

        public void ShotBulletEnemy(Vector3 pos, float spd, float dir, float dmg) {
            var bullet = Instantiate(GetPref(Pref.BulletEnemy));
            bullet.transform.position = pos;
            bullet.GetComponent<BulletEnemy>().SetData(spd, dir, dmg);
        }

        public void ShotLaserEnemy(Transform from) {
            var laser = Instantiate(GetPref(Pref.LaserEnemy));
            laser.GetComponent<LaserEnemy>().SetData(from);
        }
    }
}
