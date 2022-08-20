using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemGShield : ItemBase
    {
        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(0);
        }

        public override float GetDefBonus()
        {
            return 30f;
        }
    }
}
