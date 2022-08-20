using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class CamMove : MonoBehaviour
    {
        public Transform ship_ts;
        public float rate = 0.1f;

        // Update is called once per frame
        void FixedUpdate()
        {
            var newx = Mathf.Lerp(transform.position.x, ship_ts.position.x, rate);

            transform.position = new Vector3(newx, transform.position.y, transform.position.z);
        }
    } 
}
