using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemCannon : ItemBase
    {
        public override int Id => 1;
        public override string name => "대포";
        public override string desc => "3초마다 유도탄 발사";
        public override int price => 100;

        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(1);
        }

        public override int GetHomingNum()
        {
            return 1;
        }
    }
}
