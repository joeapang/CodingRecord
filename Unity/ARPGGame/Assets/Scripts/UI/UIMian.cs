using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class UIMian : MonoBehaviour {

    public static UIMian instance;



    public GameObject Accept_btn;
    public GameObject Cancle_btn;
    public GameObject QuestClose_btn;
    public GameObject Ok_btn;
    public GameObject InventoryClose_btn;
    public GameObject Status_btn;
    public GameObject Skill_btn;
    public GameObject Bag_btn;
    public GameObject Equip_btn;
    public GameObject Setting_btn;
    public GameObject[] QuestBoard;
    public GameObject Inventory;
    public GameObject Status;
    public GameObject shop;

    void Awake ( )
    {
        instance = this;

        UIEventListener.Get ( Accept_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( Cancle_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( QuestClose_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( Ok_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( InventoryClose_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( Skill_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( Bag_btn).onClick = ButtonOnClick;
        UIEventListener.Get ( Status_btn ).onClick = ButtonOnClick;
        UIEventListener.Get ( Equip_btn).onClick = ButtonOnClick;
        UIEventListener.Get ( Setting_btn ).onClick = ButtonOnClick;
        // characterType = PlayerPrefs.GetInt ( "Player" );
    }

   

    void Update ( )
    {

        if (Input.GetMouseButtonDown ( 0 ) && (UICamera.hoveredObject == null || UICamera.hoveredObject.name == "UI Root"))
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

            RaycastHit hitInfo;
            Physics.Raycast ( ray, out hitInfo );
            Debug.Log ( hitInfo.transform.gameObject.name );
            if (hitInfo.transform.gameObject.name == "Bar_NPC")
            {
                ShowQuest ( );
            }
            if (hitInfo.transform.gameObject.name == "Potion_Npc")
            {
                ShowShop ( );
            }
        }
    }


   
    //显示任务面板
    public void ShowQuest ( )
    {

        if (LoadQuestDataFromLocal ( 1 ) && !QuestData.instance.isAccept){
            //QuestBoard = Resources.Load ( "Prefabs/UI/Quest" ) as GameObject;
            QuestBoard[0].transform.FindChild ( "Context" ).GetComponent<UILabel> ( ).text = QuestData.instance.questString + "\n" + "\n"
                                                                                        + QuestData.instance.targetString + "\n" + "\n"
                                                                                        + "Target " + QuestData.instance.count + "\n" + "\n"
                                                                                        + "Coins " + QuestData.instance.coints + "\n" + "\n"
                                                                                        + "Exp " + QuestData.instance.exp;
            //Instantiate ( QuestBoard, QuestBoard.transform.position, QuestBoard.transform.rotation );
            QuestBoard[0].SetActive ( true );

        }
        if (QuestData.instance.isAccept)
        {
            Debug.Log ( PlayerPrefs.GetString ( "QuestContext" ) );
            QuestBoard[1].transform.FindChild ( "Context" ).GetComponent<UILabel> ( ).text = PlayerPrefs.GetString ( "QuestContext " ).Trim ( ) + "\n" + "\n"
                                                                                        + PlayerPrefs.GetString ( "QuestTarget" ) + "\n" + "\n"
                                                                                        + "Target " + PlayerPrefs.GetInt ( "QuestTargetCount" ) + "\n" + "\n"
                                                                                        + "Coins " + PlayerPrefs.GetInt ( "QuestCoins" ) + "\n" + "\n"
                                                                                        + "Exp " + PlayerPrefs.GetInt ( "QuestExp" );
            QuestBoard[1].SetActive ( true );
        }

    }


    public void ShowShop ( ) {
        shop.SetActive ( true);

    }
    /// <summary>
    /// 点击不同按钮，响应相应事件
    /// </summary>
    /// <param name="go"></param>
    private void ButtonOnClick ( GameObject go )
    {
        Debug.Log ( go.name );
        if (go.name == "Accept_btn")
        {
            QuestData.instance.isAccept = true;
            PlayerPrefs.SetString ( "QuestContext", QuestData.instance.questString );

            PlayerPrefs.SetString ( "QuestTarget", QuestData.instance.targetString );
            PlayerPrefs.SetInt ( "QuestTargetCount", QuestData.instance.count );
            PlayerPrefs.SetInt ( "QuestCoins", QuestData.instance.coints );
            PlayerPrefs.SetInt ( "QuestExp", QuestData.instance.exp );
            PlayerPrefs.Save ( );
            QuestBoard[0].SetActive ( false );
        }
        else if (go.name == "Cancle_btn")
        {
            QuestBoard[0].SetActive ( false );
            // Destroy (  );
        }
        else if (go.name == "Close_btn")
        {
            go.transform.parent.gameObject.SetActive ( false);
        }
        else if (go.name == "Ok_btn")
        {
            QuestBoard[1].SetActive ( false );
        }
        else if (go.name == "Bag") {

           Inventory.SetActive ( true );
        }
        else if (go.name == "Staus")
        {
            Status.GetComponent<Status>().TransformStatus ( );
        }

    }
    //读取本地文档
    public bool LoadQuestDataFromLocal ( int currentQuest )
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText ( @"Assets\Resources\Text\Quests\" + currentQuest + ".txt" );


        }
        catch (Exception e)
        {
            Debug.LogError ( e );
        }
        //TextAsset questText = Resources.Load ( "Quests/" + currentQuest ) as TextAsset;
        //if (questText == null)
        //{
        //    questText = Resources.Load ( "Quests/" + currentQuest ) as TextAsset;
        //}
        ProcessQuestDataFromString ( sr );
        sr.Close ( );
        sr.Dispose ( );
        return true;
    }
    //解析文档，获取任务
    void ProcessQuestDataFromString ( StreamReader questText )
    {
        ArrayList arrlist = new ArrayList ( );
        string str;
        while ((str = questText.ReadLine ( )) != null)
        {

            arrlist.Add ( str );
        }
        //Message 是任务描述，Target 是任务目标，Count 目标数量，Coins 奖励金币数量，Exp 奖励经验
        //string[] lines = questText.Split ( new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries );

        foreach (string line in arrlist)
        {
            if (line.StartsWith ( "Message" ))
            {
                string messageString = line.Replace ( "Message", string.Empty ).Trim ( );
                QuestData.instance.questString = messageString;
            }
            else if (line.StartsWith ( "Target" ))
            {
                string targetString = line.Replace ( "Target", string.Empty ).Trim ( );
                QuestData.instance.targetString = targetString;
            }
            else if (line.StartsWith ( "Count" ))
            {
                string count = line.Replace ( "Count", string.Empty ).Trim ( );
                QuestData.instance.count = int.Parse ( count );
            }
            else if (line.StartsWith ( "Coins" ))
            {
                string coins = line.Replace ( "Coins", string.Empty ).Trim ( );
                QuestData.instance.coints = int.Parse ( coins );

            }
            else if (line.StartsWith ( "Exp" ))
            {
                string exp = line.Replace ( "Exp", string.Empty ).Trim ( );
                QuestData.instance.exp = int.Parse ( exp );
            }
        }
    }

    
  
}
