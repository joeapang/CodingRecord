using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{

    public static Status instance;

    public UILabel attackLabel;
    public UILabel defLabel;
    public UILabel skillLable;
    public UILabel remianLabel;

    public GameObject attackPlus_btn;
    public GameObject defPlus_btn;
    public GameObject skillPlus_btn;


    void Awake ( )
    {
        instance = this;

        UIEventListener.Get ( attackPlus_btn ).onClick = OnPlusBtnClick;
        UIEventListener.Get ( defPlus_btn ).onClick = OnPlusBtnClick;
        UIEventListener.Get ( skillPlus_btn ).onClick = OnPlusBtnClick;
    }
    void Start ( )
    {

        UpdateData ( );
    }
    /// <summary>
    /// 跟新显示面板
    /// </summary>
    public void UpdateData ( )
    {
        PlayStatus.instance.GetStatusDate ( );
        attackLabel.text = PlayStatus.instance.attack + "+" + PlayStatus.instance.attack_plus;
        defLabel.text = PlayStatus.instance.def + "+" + PlayStatus.instance.def_plus;
        skillLable.text = PlayStatus.instance.skillAttack + "+" + PlayStatus.instance.skillAttack_plus;

        remianLabel.text = PlayStatus.instance.remain+"";


        if (PlayStatus.instance.remain > 0)
        {
            attackPlus_btn.SetActive ( true );
            defPlus_btn.SetActive ( true );
            skillPlus_btn.SetActive ( true );
        }
        else
        {
            attackPlus_btn.SetActive ( false );
            defPlus_btn.SetActive ( false );
            skillPlus_btn.SetActive ( false );
        }

    }

    public void TransformStatus ( )
    {
        this.transform.gameObject.SetActive ( !transform.gameObject.activeSelf );
        UpdateData ( );
    }

    public void OnPlusBtnClick ( GameObject go )
    {
        if (PlayStatus.instance.remain > 0)
        {
            switch (go.name)
            {
                case "AttackPlus_btn":
                    PlayStatus.instance.attack_plus++;

                    break;
                case "DefPlus_btn":
                    PlayStatus.instance.def_plus++;
                    break;
                case "SkillPlus_btn":
                    PlayStatus.instance.skillAttack_plus++;
                    break;
            }

            PlayStatus.instance.remain--;
        }
        UpdateData ( );
        PlayStatus.instance.SaveStatusData ( );
    }
}
