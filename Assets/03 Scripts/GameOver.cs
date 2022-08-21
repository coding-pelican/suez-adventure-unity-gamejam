using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class GameOver : MonoBehaviour
    {
        public void Restart()
        {
            //pplication.LoadLevel(0);

            GameManager.Instance.Init();
    
            gameObject.SetActive(false);
        }
    } 
}
