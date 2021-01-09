using UnityEngine;
using UnityEngine.UI;

public class HeroPlayer : HeroOne
{
    private Button btnskill1;
    private Button btnskill2;
    private Button btnskill3;
    private Button btnskill4;

    private Image[] imgSkillsCD = new Image[4];
    private Image[] imgSkills = new Image[4];
    private Text[] textSkills = new Text[4];
    /// <summary>
    /// 目標物件
    /// </summary>
    private Transform target;
    private Joystick joy;
    private Transform camRoot;

    [Header("移動的距離"), Range(0f, 5f)]
    public float moveDistance = 2;

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.Find("模型").transform;
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
        camRoot = GameObject.Find("攝影機根物件").transform;
        SetButtonUI();

    }

    protected override void Update()
    {
        base.Update();
        MoveControl();
        UpdateSkillCD();
    }

    private void MoveControl ()
    {
        float v = joy.Vertical;
        float h = joy.Horizontal;
        //目標物件.座標 = 角色.座標 + 攝影機根物件.前方 * 垂直 * 距離 + 攝影機根物件.右邊 * 水平 * 距離
        target.position = transform.position + camRoot.forward * v * moveDistance + camRoot.right * h * moveDistance;
        //移動(目標物件)
        Move(target);
    }

    private void SetButtonUI()
    {

        btnskill1 = GameObject.Find("技能1").GetComponent<Button>();
        btnskill2 = GameObject.Find("技能2").GetComponent<Button>();
        btnskill3 = GameObject.Find("技能3").GetComponent<Button>();
        btnskill4 = GameObject.Find("技能4").GetComponent<Button>();

        btnskill1.onClick.AddListener(skill1);
        btnskill2.onClick.AddListener(skill2);
        btnskill3.onClick.AddListener(skill3);
        btnskill4.onClick.AddListener(skill4);
        for (int i = 0; i < 4; i++)
        {
            imgSkills[i] = GameObject.Find("技能圖片" + (i + 1)).GetComponent<Image>();
            imgSkillsCD[i] = GameObject.Find("技能冷卻圖片" + (i + 1)).GetComponent<Image>();
            textSkills[i] = GameObject.Find("技能數字" + (i + 1)).GetComponent<Text>();
            imgSkills[i].sprite = Date.skills[i].image;
            textSkills[i].text = "";
        }
    }
    private void UpdateSkillCD()
    {
        for (int i = 0; i < 4; i++)
        {
            if (skillStart[i])
            {
                textSkills[i].text = (Date.skills[i].cd - skillTimer[i]).ToString("F0");
                imgSkillsCD[i].fillAmount = (Date.skills[i].cd - skillTimer[i]) / Date.skills[i].cd;
            }
            else
            {
                imgSkillsCD[i].fillAmount = 0;
                textSkills[i].text = "";

            }
        }
    }
}


