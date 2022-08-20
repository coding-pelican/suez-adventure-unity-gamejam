using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suez
{
    public class ItemManager : MonoBehaviour
    {
        List<ItemBase> item_list = new();

        private void Awake() {
            item_list.Add(new ItemGShield());
        }

        public ItemBase GetItem(int index) {
            if (index == -1) return null;
            return item_list[index];
        }
    }
}
