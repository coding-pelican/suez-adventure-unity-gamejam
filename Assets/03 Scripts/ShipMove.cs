using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class ShipMove : MonoBehaviour {
        public float mspd = 3f;
        public float rate = 0.1f;

        public float xmin;
        public float xmax;

        private KeyCode key_left = KeyCode.LeftArrow;
        private KeyCode key_right = KeyCode.RightArrow;
        private float xspd;

        private int xInput;
        private GameManager _gm;

        public float XInput { get => xInput; }

        private void Awake() {
            _gm = GameManager.Instance;
        }

        private void Start() {
            xspd = 0;
            xInput = 0;
        }

        private void Update() {
            if (!_gm.IsCurGameFlowField()) return;
            xInput = (Input.GetKey(key_left) ? -1 : 0) + (Input.GetKey(key_right) ? 1 : 0);
            _gm.PlayerXInput = xInput;
        }

        private void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            xspd = Mathf.Lerp(xspd, xInput * mspd, rate);

            var xnew = Mathf.Clamp(transform.position.x + xspd * Time.fixedDeltaTime, xmin, xmax);

            transform.position = new Vector3(xnew, transform.position.y, transform.position.z);
        }
    }
}
