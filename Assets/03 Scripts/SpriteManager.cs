using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite GetSpr(int index)
    {
        return sprites[index];
    }
}
