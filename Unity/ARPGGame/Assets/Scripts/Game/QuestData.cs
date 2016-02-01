using UnityEngine;
using System.Collections;
/// <summary>
/// 管理任务信息和状态
/// </summary>
public class QuestData : MonoBehaviour {

    public static QuestData instance;
    public  string questString;
    public  string targetString;
    public  int count;
    public  int coints;
    public  int exp;
    public  bool isAccept;

    void Awake ( ) {
        instance = this;
    }
}
