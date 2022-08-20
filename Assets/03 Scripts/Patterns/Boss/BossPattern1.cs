using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class BossPattern1 : MonoBehaviour
    {
        GameManager gm = null;

        IPatternBoss pattern = null;
        IMove move = null;

        int frame;

        public Material spr1;
        public Material spr2;

        public MeshRenderer _bossRenderer;

        int ani_state;

        private void Awake()
        {
            gm = GameManager.Instance;
            gm.Boss = this.gameObject;
            gameObject.SetActive(false);
        }

        // Start is called before the first frame update
        private void OnEnable()
        {
            pattern = new PatternWait();
            move = new MoveSlow(5f, 0f, new Vector3(0f, 0.5f, 50f));

            pattern.Init(transform);
            move.Init(transform);

            frame = 0;

            ani_state = 0;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!gm.IsCurGameFlowField()) return;

            pattern.Step(frame, transform, out bool finish_pattern);

            move.Step(frame, transform, out bool finish_move);

            if (frame >= 120) ani_state = 0;

            frame += 1;

            if (finish_pattern)
            {
                pattern = Random.Range(0, 2) == 0 ? new Pattern3Way() : new PatternLaserBoss();
                pattern.Init(transform);
                frame = 0;
                ani_state = 1;
            }
            if (finish_move) gameObject.SetActive(false);

            _bossRenderer.material = ani_state switch
            {
                0 => spr1,
                _ => spr2,
            };
        }
    }

    public class PatternWait : IPatternBoss
    {
        public void Init(Transform transform)
        {
            //pass
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            if (frame >= 300) finish = true;
            else finish = false;
        }
    }

    public class Pattern3Way : IPatternBoss
    {
        GameManager gm = null;

        Transform player_ts = null;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;

            player_ts = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            for (var i = 0; i < 3; i++)
            {
                if (frame % (50 * 3) == i * 15 + 50)
                {
                    var dir = Vector3.Angle(Vector3.right, player_ts.position - (transform.position + Vector3.right * 3f)) * -Mathf.Deg2Rad;
                    gm.ShotBulletEnemy(transform.position + Vector3.right * 3f, 9f, dir - 0.42f, 1f);
                    gm.ShotBulletEnemy(transform.position + Vector3.right * 3f, 9f, dir, 1f);
                    gm.ShotBulletEnemy(transform.position + Vector3.right * 3f, 9f, dir + 0.42f, 1f);
                    dir = Vector3.Angle(Vector3.right, player_ts.position - (transform.position + Vector3.left * 3f)) * -Mathf.Deg2Rad;
                    gm.ShotBulletEnemy(transform.position + Vector3.left * 3f, 9f, dir - 0.42f, 1f);
                    gm.ShotBulletEnemy(transform.position + Vector3.left * 3f, 9f, dir, 1f);
                    gm.ShotBulletEnemy(transform.position + Vector3.left * 3f, 9f, dir + 0.42f, 1f);
                }
            }

            if (frame >= 300) finish = true;
            else finish = false;
        }
    }

    public class PatternLaserBoss : IPatternBoss
    {
        GameManager gm = null;

        Transform player_ts = null;

        bool left;

        public void Init(Transform transform)
        {
            gm = GameManager.Instance;

            player_ts = GameObject.FindGameObjectWithTag("Player").transform;

            left = player_ts.position.x < 0f;
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            if (frame == 50)
            {
                for (var i = -3; i <= 3; i++)
                {
                    gm.ShotLaserBoss(transform.position + Vector3.up * 3f + Vector3.left * 3f, (left ? Vector3.left : Vector3.right) * 1.5f + Vector3.right * i*0.65f);
                    gm.ShotLaserBoss(transform.position + Vector3.up * 3f + Vector3.right * 3f, (left ? Vector3.left : Vector3.right) * 1.5f + Vector3.right * i*0.65f);
                }
            }

            if (frame == 125) gm.PlaySfx(5);


            if (frame >= 230) finish = true;
            else finish = false;
        }
    }

    public class MoveSlow : IMove
    {
        float spd;
        float dir;
        Vector3 ipos;

        float zmin;

        public MoveSlow(float _spd, float _dir, Vector3 _ipos)
        {
            spd = _spd;
            dir = _dir;
            ipos = _ipos;

            zmin = 8f;
        }

        public void Init(Transform transform)
        {
            transform.position = ipos;
        }

        public void Step(int frame, Transform transform, out bool finish)
        {
            if (transform.position.z >= zmin)
                transform.position += Vector3.back * spd * Time.fixedDeltaTime;
            finish = false;
        }
    }
}
