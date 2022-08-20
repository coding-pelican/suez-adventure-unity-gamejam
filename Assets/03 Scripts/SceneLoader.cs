using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class SceneLoader : MonoBehaviour {
        public GameManager gameManager;

        void Awake() {
            //if (GameManager.Instance == null) {
            //    Instantiate(gameManager);
            //}
            Application.targetFrameRate = 30;
        }
    } 
}