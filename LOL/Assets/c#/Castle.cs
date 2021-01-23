using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Tower
{
  
    [Header("勝利圖片")]
    public GameObject goVictory;
       [Header("失敗圖片")]
    public GameObject goDefeat;
        [Header("勝利音效")]
    public AudioClip soundVictory;
        [Header("失敗音效")]
    public AudioClip soundDefrat;
        [Header("是否為敵方")]
    public bool isEnemy = true;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    protected override void Dead()
    {
        base.Dead();
        //如果勝利 播放勝利圖片、音效
        if (isEnemy)
        {
            goVictory.SetActive(true);
            aud.PlayOneShot(soundVictory, 1.2f);
        }
        //否則播放 失敗圖片、音效
        else
        {
            goDefeat.SetActive(true);
            aud.PlayOneShot(soundDefrat, 1.2f);
        }
    }

}
