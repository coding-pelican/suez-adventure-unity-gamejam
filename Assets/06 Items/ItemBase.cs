using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    public class ItemBase
    {
        public virtual Sprite GetSpr()
        {
            return null;
        }

        public virtual void Init()
        {
            return;
        }

        public virtual float GetDmgBonus()
        {
            return 0f;
        }

        public virtual float GetDmgMultiply()
        {
            return 1f;
        }

        public virtual float GetDefBonus()
        {
            return 0f;
        }

        public virtual void OnGetDmg()
        {
            return;
        }

        public virtual void OnAttack(GameObject target)
        {
            return;
        }

        public virtual void BeforeStep()
        {
            return;
        }

        public virtual void AfterStep()
        {
            return;
        }
    } 
}
