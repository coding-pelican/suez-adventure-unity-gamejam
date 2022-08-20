using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemGShield : ItemBase
    {
        public override int Id => 0;
        public override string name => "대방패";
        public override string desc => "방어력+30";
        public override int price => 100;

        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(0);
        }

        public override float GetDefBonus()
        {
            return 30f;
        }

        public override float GetDmgBonus()
        {
            return 1f;
        }

        public override int GetHomingNum()
        {
            return 1;
        }
    }
}
