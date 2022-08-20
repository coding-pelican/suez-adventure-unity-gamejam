using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sfx;
    public AudioClip[] bgm;

    public AudioClip GetSfx(int index)
    {
        return sfx[index];
    }

    public AudioClip GetBgm(int index)
    {
        return bgm[index];
    }
}
