using UnityEngine;
using UnityEngine.UI;

public class HeroOne : MonoBehaviour
{
    [Header("角色資料")]
    public Herocontrol date;
    [Header("重生點")]
    public Transform restart;
    [Header("圖層")]
    public int layer;
    protected Animator ani;
    private Rigidbody rig;
    private Text texthp;
    private Image imghp;
    private Transform canvasHP;
    protected float[] skillTimer = new float[4];
    protected bool[] skillStart = new bool[4];
    private float hp;
    private float hpMax;
    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        canvasHP = transform.Find("畫布血條");
        texthp = canvasHP.Find("血條文字").GetComponent<Text>();
        texthp.text = date.hp.ToString();
        texthp = canvasHP.Find("血條").GetComponent<Text>();

    }
    protected virtual void Update()
    {
        TimetControl();

    }
    private void Start()
    {
        hp = date.hp;
        hpMax = hp;
    }
    public void Damage(float damage)
    {
        hp -= damage;
        texthp.text = hp.ToString();
        imghp.fillAmount = hp / hpMax;
    }
/// <summary>
/// 死亡
/// </summary>
    private void Dead()
    {
        texthp.text = "0";
        enabled = false;
        ani.SetBool("死亡開關", true);
        gameObject.layer = 0;            //避免被鞭屍
       
    }
    /// <summary>
    /// 重生
    /// </summary>
    private void Restart()
    {
        hp = hpMax;
        texthp.text = hp.ToString();
        imghp.fillAmount = 1;
        enabled = true;
        transform.parent = restart.parent;
        gameObject.layer = layer;
        ani.SetBool("死亡開關",false);

    }

    private void TimetControl()
    {
        for (int i = 0; i < 4; i++)
        {
            if (skillStart[i])
            {
                skillTimer[i] += Time.deltaTime;
                if (skillTimer[i] >= date.skills[i].cd)
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
protected virtual void Move(Transform targrt)
    {
        Vector3 pos = rig.position;
        //剛體.移動座標(座標)
        rig.MovePosition(targrt.position);
        transform.LookAt(targrt);
        ani.SetBool("跑步開關", rig.position != pos);
        canvasHP.eulerAngles = new Vector3(-60, 180, 0);
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
