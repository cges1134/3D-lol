
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("要追蹤的物件")]
    public Transform target;
    [Header("追蹤速度")]
    public float speed = 3;

    private void Track()
    {

    }

    private void Update()
    {
        Track();
    }


}
