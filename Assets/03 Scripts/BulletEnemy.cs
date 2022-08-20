using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class BulletEnemy : MonoBehaviour
    {
        public float spd;
        public float dir;

        public float dmg;

        public float zmin;
        public float zmax;

        public void SetData(float _spd, float _dir, float _dmg)
        {
            spd = _spd;
            dir = _dir;
            dmg = _dmg;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3.right * Mathf.Cos(dir) + Vector3.forward * Mathf.Sin(dir)) * spd * Time.deltaTime;

            if (transform.position.z < zmin || transform.position.z > zmax) Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var tag = collision.gameObject.tag;
            if (tag == "Side") Destroy(gameObject);
        }
    } 
}
