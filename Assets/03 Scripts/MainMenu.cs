using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez {
    public class MainMenu : MonoBehaviour {
        GameManager _gm;

        private void Awake() {
            _gm = GameManager.Instance;
        }

        public void OnClickStart() {
            _gm.CurGameFlow = EGameFlow.Field;
            if (gameObject.activeSelf) {
                gameObject.SetActive(false);
            }
            _gm.PlayGame();
            _gm.PlayBgm(0);
        }

        public void OnClickExit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }
    }

}