using UnityEngine;
using UnityEngine.UI;

public class HeroPlayer : HeroOne
{
    private Button btnskill1;
    private Button btnskill2;
    private Button btnskill3;
    private Button btnskill4;

    private Image[] imgSkills = new Image[4];
    private Text[] textSkills = new Text[4];


    protected override void Awake()
    {
        base.Awake();

        SetButtonUI();
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
            textSkills[i] = GameObject.Find("技能數字" + (i + 1)).GetComponent<Text>();
            imgSkills[i].sprite = Date.skills[i].image;
            textSkills[i].text = "";
        }
    }
}


