
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("攻擊範圍"), Range(0, 500)]
    public float rangeAtk;
    [Header("攻擊力"), Range(0, 500)]
    public float Atk;
    [Header("生成物件")]
    public GameObject psBullet;
    [Header("速度"), Range(0, 5000)]
    public float speedBullet;
    [Header("攻擊圖層")]
    public int layer;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);               //顏色
        Gizmos.DrawSphere(transform.position, rangeAtk);       //繪製圖形(中心點半徑)

    }

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, rangeAtk, 1 << layer);

        for (int i = 0; i < hit.Length; i++)
        {
            print(hit[i].name);
        }

    }

}
