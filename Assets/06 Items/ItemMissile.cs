using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemMissile : ItemBase
    {
        public override int Id => 2;
        public override string name => "미사일";
        public override string desc => "공격력 +0.5, 방어력 +10%";
        public override int price => 100;

        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(2);
        }

        public override float GetDmgBonus()
        {
            return 0.5f;
        }

        public override float GetDefBonus()
        {
            return 10f;
        }
    }
}
