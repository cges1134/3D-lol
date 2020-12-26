using UnityEngine;

public class HeroOne : MonoBehaviour
{
    [Header("角色資料")]
    public Herocontrol Date;
    protected Animator ani;
    private float [] skillTimer = new float[4];
    private bool[] skillStart = new bool[4];

    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Move()
    {

    }

    public void skill1()
    {
        ani.SetTrigger("第一招");
    }

    public void skill2()
    {
        ani.SetTrigger("第二招");
    }

    public void skill3()
    {
        ani.SetTrigger("第三招");
    }

    public void skill4()
    {
        ani.SetTrigger("大招");
    }
}
