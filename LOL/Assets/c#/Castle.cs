using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Tower
{
    /// <summary>
    /// 勝利圖片
    /// </summary>
    public GameObject goVictory;
    /// <summary>
    /// 失敗圖片
    /// </summary>
    public GameObject goDefeat;
    /// <summary>
    /// 勝利音效
    /// </summary>
    public AudioClip soundVictory;
    /// <summary>
    /// 失敗音效
    /// </summary>
    public AudioClip soundDefrat;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

}
