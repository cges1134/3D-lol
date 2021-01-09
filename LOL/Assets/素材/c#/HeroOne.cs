using UnityEngine;

public class HeroOne : MonoBehaviour
{
    [Header("角色資料")]
    public Herocontrol Date;
    protected Animator ani;
    private float[] skillTimer = new float[4];
    private bool[] skillStart = new bool[4];
    private Rigidbody rig;
    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }
    protected virtual void Update()
    {
        TimetControl();
       
    }
    private void TimetControl()
    {
        for (int i = 0; i < 4; i++)
        {
            if (skillStart[i])
            {
                skillTimer[i] += Time.deltaTime;
                if (skillTimer[i] >= Date.skills[i].cd)
                {
                    skillTimer[i] = 0;
                    skillStart[i] = false;
                }

            }
        }
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="targrt">要前往的目標位置</param>
    public void Move(Transform targrt)
    {
        //剛體.移動座標(座標)
        rig.MovePosition(targrt.position);
    }

    public void skill1()
    {
        if (skillStart[0]) return;
        ani.SetTrigger("第一招");
        skillStart[0] = true;
    }

    public void skill2()
    {
        if (skillStart[1]) return;
        ani.SetTrigger("第二招");
        skillStart[1] = true;
    }

    public void skill3()
    {
        if (skillStart[2]) return;
        ani.SetTrigger("第三招");
        skillStart[2] = true;
    }

    public void skill4()
    {
        if (skillStart[3]) return;
        ani.SetTrigger("大招");
        skillStart[3] = true;
    }
}
