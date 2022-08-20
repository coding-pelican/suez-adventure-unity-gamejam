using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Suez
{
    class ItemGatling : ItemBase
    {
        public override int Id => 3;
        public override string name => "개틀링 건";
        public override string desc => "1초마다 유도탄 발사";
        public override int price => 100;

        public override Sprite GetSpr()
        {
            return GameManager.Instance.GetSpr(3);
        }

        public override int GetHomingNum()
        {
            return 3;
        }

        }
    }
}
