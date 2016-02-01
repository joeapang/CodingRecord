using UnityEngine;
using System.Collections;

public class PlayStatus : MonoBehaviour
{
    public static PlayStatus instance;

    public int level;//等级
    public int hp = 100;//hp值
    public int mp = 100;//mp值
    public int attack = 20;//攻击力
    public int def = 20;//防御
    public int skillAttack = 20;//魔法攻击力
    public int attack_plus = 0;//攻击属性点加成
    public int def_plus = 0;//防御属性点加成
    public int skillAttack_plus = 0;//魔法攻击属性加成
    public int remain = 30;//剩余属性点

    void Awake ( )
    {
        instance = this;
    }
    /// <summary>
    ///把属性存到PlayerPrefab中
    /// </summary>
    public void SaveStatusData ( )
    {
        PlayerPrefs.SetInt ( "Level", PlayStatus.instance.level );
        PlayerPrefs.SetInt ( "Acctack", PlayStatus.instance.attack );
        PlayerPrefs.SetInt ( "Def", PlayStatus.instance.def );
        PlayerPrefs.SetInt ( "Skill", PlayStatus.instance.skillAttack );
        PlayerPrefs.SetInt ( "Remain", PlayStatus.instance.remain );
        PlayerPrefs.SetInt ( "Acctack_Plus", PlayStatus.instance.attack_plus );
        PlayerPrefs.SetInt ( "Def_Plus", PlayStatus.instance.def_plus );
        PlayerPrefs.SetInt ( "Skill_Plus", PlayStatus.instance.skillAttack_plus );
    }

    public void GetStatusDate ( )
    {
        PlayStatus.instance.level = PlayerPrefs.GetInt ( "Level" );
        PlayStatus.instance.attack = PlayerPrefs.GetInt ( "Acctack" );
        PlayStatus.instance.def = PlayerPrefs.GetInt ( "Def" );
        PlayStatus.instance.skillAttack = PlayerPrefs.GetInt ( "Skill" );
        PlayStatus.instance.remain = PlayerPrefs.GetInt ( "Remain" );
        PlayStatus.instance.attack_plus = PlayerPrefs.GetInt ( "Acctack_Plus" );
        PlayStatus.instance.def_plus = PlayerPrefs.GetInt ( "Def_Plus" );
        PlayStatus.instance.skillAttack_plus = PlayerPrefs.GetInt ( "Skill_Plus" );
    }
}
