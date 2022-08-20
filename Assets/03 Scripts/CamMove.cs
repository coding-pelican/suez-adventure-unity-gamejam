using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class CamMove : MonoBehaviour {
        public Transform shipTs;
        public float rate = 0.1f;

        private GameManager _gm;
        [SerializeField] private Material _shipNormal;
        [SerializeField] private Material _shipMovedLeft;
        [SerializeField] private Material _shipMovedRight;
        private MeshRenderer _shipRenderer;

        private void Awake() {
            _gm = GameManager.Instance;
            _shipRenderer = shipTs.gameObject.GetComponent<MeshRenderer>();
        }

        private void FixedUpdate() {
            if (!_gm.IsCurGameFlowField()) return;
            var newx = Mathf.Lerp(transform.position.x, shipTs.position.x, rate);
            transform.position = new Vector3(newx, transform.position.y, transform.position.z);
            _shipRenderer.material = _gm.PlayerXInput switch {
                1 => _shipMovedRight,
                -1 => _shipMovedLeft,
                _ => _shipNormal,
            };
        }
    }
}
