using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

public class GameMain : MonoBehaviour
{
    public static GameMain instance;

    public GameObject charaterPos;
    public GameObject magician;
    public GameObject swordman;
    public int characterType = 1;
    public bool isRun;
    public Text runText;

    

    void Awake ( )
    {
        instance = this;
        isRun = true;


    }
    // Use this for initialization
    void Start ( )
    {
        CharaterSpwan ( );

    }

   

    //生成角色
    void CharaterSpwan ( )
    {

        GameObject player = null;

        if (characterType == 1)
        {
            player = Instantiate ( magician, charaterPos.transform.position, magician.transform.rotation ) as GameObject;
        }
        else if (characterType == 2)
        {
            player = Instantiate ( swordman, charaterPos.transform.position, swordman.transform.rotation ) as GameObject;

        }
        if (player != null)
        {
            player.transform.parent = charaterPos.transform;
            player.transform.LookAt ( new Vector3 ( Camera.main.transform.position.x, player.transform.position.y, Camera.main.transform.position.z ) );
        }
    }
    //是否可以跑动
    public void OnRunButtonClick ( )
    {
        if (isRun)
        {
            isRun = false;
            PlayerPrefs.SetInt ( "Runable", 0 );
            runText.enabled = false;

        }
        else
        {
            isRun = true;
            runText.enabled = true;
            PlayerPrefs.SetInt ( "Runable", 1 );
        }
        PlayerPrefs.Save ( );
    }
   

    
}
