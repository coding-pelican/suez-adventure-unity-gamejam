using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class UIControl : MonoBehaviour
    {
        public GameObject UIClear;
        public GameObject UIGameOver;

        GameManager gm = null;

        private void Awake()
        {
            gm = GameManager.Instance;
        }

        void FixedUpdate()
        {
            if(gm.CurGameFlow == EGameFlow.GameEnding)
            {
                UIClear.SetActive(true);
            }
            else if(gm.CurGameFlow == EGameFlow.GameOver)
            {
                UIGameOver.SetActive(true);
            }
            else
            {
                UIClear.SetActive(false);
                UIGameOver.SetActive(false);
            }
        }
    } 
}

