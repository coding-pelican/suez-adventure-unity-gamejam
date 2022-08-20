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

        public float xmin;
        public float xmax;

        public void SetData(float _spd, float _dir, float _dmg)
        {
            spd = _spd;
            dir = _dir;
            dmg = _dmg;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position += (Vector3.right * Mathf.Cos(dir) + Vector3.forward * Mathf.Sin(dir)) * spd * Time.fixedDeltaTime;

            if (transform.position.z < zmin || transform.position.z > zmax) Destroy(gameObject);
            if (transform.position.x < xmin || transform.position.x > xmax) Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var tag = other.gameObject.tag;
            if (tag == "Side") Destroy(gameObject);
        }
    } 
}
