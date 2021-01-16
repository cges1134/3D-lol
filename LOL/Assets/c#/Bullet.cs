
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float atk;
    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;

        posB = Vector3.Lerp(posB, posA, Time.deltaTime * 0.5f * speed);
        transform.position = posB;
        if (Vector3.Distance(posB, posA)<1)
        {
            target.GetComponent<HeroPlayer>().Damage(atk);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Track();
    }







}
