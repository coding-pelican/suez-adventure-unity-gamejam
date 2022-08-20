using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class GroundScrollingRecycler : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.0f;
        [SerializeField] private float _gameSpeed = 0.0f;
        [SerializeField] private float _startYPosition = 0.0f;
        [SerializeField] private float _endZPosition = 0.0f;
        [SerializeField] private float _quadWidth = 0.0f;
        [SerializeField] private float _padding = 0.0f;
        [SerializeField] private Material _parallaxMaterial;
        [SerializeField] private MeshRenderer[] _parallaxRenderers;
        private MeshRenderer _firstRenderer;

        private void Awake()
        {
            _parallaxRenderers = GetComponentsInChildren<MeshRenderer>();
            _firstRenderer = _parallaxRenderers[0];
            ChangeTilesToCurTile();
        }

        private void Update()
        {
            for (int i = 0; i < _parallaxRenderers.Length; i++)
            {
                if (_endZPosition >= _parallaxRenderers[i].transform.position.z)
                {
                    for (int q = 0; q < _parallaxRenderers.Length; q++)
                    {
                        if (_firstRenderer.transform.position.z < _parallaxRenderers[q].transform.position.z)
                            _firstRenderer = _parallaxRenderers[q];
                    }
                    _parallaxRenderers[i].transform.position = new Vector3(_firstRenderer.transform.position.x, _startYPosition, _firstRenderer.transform.position.z + _quadWidth + _padding);
                    _parallaxRenderers[i].material = _parallaxMaterial;
                }
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _parallaxRenderers.Length; i++)
            {
                _parallaxRenderers[i].transform.Translate(_speed * _gameSpeed * 0.1f * Time.fixedDeltaTime * new Vector3(0, -1, 0));
            }
        }

        private void ChangeTilesToCurTile()
        {
            for (int i = 0; i < _parallaxRenderers.Length; i++)
            {
                _parallaxRenderers[i].material = _parallaxMaterial;
            }
        }
    } 
}