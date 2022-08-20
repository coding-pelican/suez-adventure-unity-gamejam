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
        private AudioManager audio_manager;
        private AudioSource ch_sfx;
        private AudioSource ch_bgm;
        private float playerXInput;
        private EGameFlow _curGameFlow;
        private List<EStageFlow> _stages = new();

        private GameObject boss;
        public GameObject Boss { get => boss; set => boss = value; }

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
            PlayerPrefs.SetInt("Slot0", 0);
            PlayerPrefs.SetInt("Slot1", -1);
            PlayerPrefs.SetInt("Slot2", -1);
            PlayerPrefs.SetInt("Slot3", -1);
            PlayerPrefs.SetInt("Slot4", -1);
            PlayerPrefs.SetInt("Slot5", -1);
            PlayerPrefs.SetInt("Slot6", -1);
            PlayerPrefs.SetInt("Slot7", -1);

            PlayerPrefs.SetFloat("Progress", 0f);

            InitAwake();
        }

        private void OnEnable() {
            // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }

        private void InitAwake() {
            prefab_manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManagerGame>();
            sprite_manager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<SpriteManager>();
            item_manager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
            audio_manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            AudioSource[] temp = audio_manager.GetComponents<AudioSource>();
            ch_sfx = temp[0];
            ch_bgm = temp[1];

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
            if(hp_new <= 0)
            {
                Debug.Log("게임오버!");
            }
        }

        public void IncreaseHp(float amount) {
            var hp_max = PlayerPrefs.GetFloat("HpMax");
            var hp_new = PlayerPrefs.GetFloat("Hp") + amount;
            PlayerPrefs.SetFloat("Hp", Mathf.Min(hp_new, hp_max));
        }

        public void GetGold(int amount)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + amount);
        }

        public bool UseGold(int amount)
        {
            var gold_new = PlayerPrefs.GetInt("Gold") - amount;
            if (gold_new < 0) return false;
            PlayerPrefs.SetInt("Gold", gold_new);
            return true;
        }

        public void ShotBulletEnemy(Vector3 pos, float spd, float dir, float dmg)
        {
            var bullet = Instantiate(GetPref(Pref.BulletEnemy));
            bullet.transform.position = pos;
            bullet.GetComponent<BulletEnemy>().SetData(spd, dir, dmg);

            PlaySfx(1);
        }

        public void ShotLaserEnemy(Transform from)
        {
            var laser = Instantiate(GetPref(Pref.LaserEnemy));
            laser.GetComponent<LaserEnemy>().SetData(from);
        }

        public void ShotLaserBoss(Vector3 from, Vector3 to)
        {
            var laser = Instantiate(GetPref(Pref.LaserBoss));
            laser.GetComponent<LaserBoss>().SetData(from, to);
        }

        public void PlaySfx(int index)
        {
            ch_sfx.PlayOneShot( audio_manager.GetSfx(index) );
        }
        public void PlayBgm(int index)
        {
            ch_bgm.clip = audio_manager.GetBgm(index);
            ch_bgm.Play();
        }


        public void ResetProgress()
        {
            PlayerPrefs.SetFloat("Progress", 0f);
        }

        public void AddProgress(float amount)
        {
            PlayerPrefs.SetFloat("Progress", PlayerPrefs.GetFloat("Progress") + amount);

            if (PlayerPrefs.GetFloat("Progress") >= 60f)
            {
                Stages[0] += 1;
                if(Stages[0] == EStageFlow.L3)
                {
                    Debug.Log("Boss Appeared!");
                    _enemySpawner.gameObject.SetActive(false);
                    Boss.SetActive(true);
                }
                else if (Stages[0] == EStageFlow.Clear)
                {
                    //클리어 화면 표시
                    Debug.Log("클리어!");
                }
                else
                {
                    Debug.Log("스테이지 클리어!");
                    if(!_enemySpawner.gameObject.activeSelf) _enemySpawner.gameObject.SetActive(true);
                    _enemySpawner.minSpawningTime -= 1;
                    _enemySpawner.maxSpawningTime -= 1;
                    if(Boss.activeSelf) Boss.SetActive(false);
                    _enemySpawner.SStart();
                }
                ResetProgress();
            }
        }
    }
}
