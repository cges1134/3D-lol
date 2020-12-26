using UnityEngine;
[CreateAssetMenu(fileName = "英雄資料", menuName = "ID/英雄資料")]
public class Herocontrol : ScriptableObject
{
    [Header("血量"), Range(100, 500)]
    public float hp;

    [Header("魔力"), Range(50, 500)]
    public float mp;

    [Header("攻擊力"), Range(10, 100)]
    public float attack;

    [Header("移動速度"), Range(100, 500)]
    public float speed;

    [Header("攻擊速度"), Range(100, 500)]
    public float attackspeed;

    // 類型後加上 []：陣列 - 儲存多筆相同類型的資料
    [Header("技能組")]
    public skill[] skills;
}

[System.Serializable]
public class skill 
    {
    public string name;
    [Header("攻擊"), Range(100, 500)]
    public float attack;
    [Header("消耗"), Range(100, 500)]
    public float cost;
    [Header("冷卻"), Range(100, 500)]
    public float cd;
    [Header("圖片")]
    public Sprite image;
}