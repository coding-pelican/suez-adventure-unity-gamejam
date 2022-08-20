using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemShield : ItemBase
    {
        public override int Id => 4;
        public override string name => "화염";
        public override string desc => "주는 데미지 2배";
        public override int price => 100;

        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(4);
        }

        public override float GetDmgMultiply()
        {
            return 2f;
        }
    }
}
