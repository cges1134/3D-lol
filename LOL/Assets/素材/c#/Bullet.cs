
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    private void Track ()
{
        Vector3 posA = target.position;
        Vector3 posB = transform.position;

        posB = Vector3.Lerp(posB, posA, Time.deltaTime * 0.5f * speed);
        transform.position = posB;

    }
    private void Update()
    {
        Track();
    }







}
