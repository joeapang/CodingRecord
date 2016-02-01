using UnityEngine;
using System.Collections;

public class CreateCharacter : MonoBehaviour
{
    public GameObject magician;
    public GameObject swordman;
    public GameObject magicianZero;
    public GameObject swordmanZero;
    public GameObject characterTaget;//角色应该移动到的位置
    public bool isChoosed = false;//是否选择了角色
    public GameObject ok_btn;
    GameObject go;
    public float timer = 0;
    public UIInput playerName;


    void Awake ( ) {
        UIEventListener.Get ( ok_btn ).onClick = OnOkButtonClick;

    }
    void Update ( )
    {
        if (Input.GetMouseButton ( 0 ))
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
            RaycastHit hit;
            if (Physics.Raycast ( ray, out hit ))
            {
                go = hit.transform.gameObject;
                if (go.name == "MagicianOnChreate" || go.name == "SwordmanOnChreate")
                {
                    if (go.name == "MagicianOnChreate")
                    {
                        go.GetComponent<Animation> ( ).Play ( "Walk" );
                        swordman.transform.position = swordmanZero.transform.position;
                        swordman.GetComponent<Animation> ( ).Play ( "Sword-Idle" );
                        isChoosed = true;
                    }
                    else if (go.name == "SwordmanOnChreate")
                    {
                        go.GetComponent<Animation> ( ).Play ( "Sword-Walk" );
                        magician.transform.position =  magicianZero.transform.position;
                        magician.GetComponent<Animation> ( ).Play ( "Idle" );
                        isChoosed = true;
                    }

                }

            }

        }

        if (go != null && isChoosed == true)
        {
            //角色从原点移到创建台上
            if (go.transform.position != characterTaget.transform.position)
            {
                StartCoroutine ( CharacterMove ( go, go.transform.position, characterTaget.transform.position ) );
                go.transform.LookAt ( Camera.main.transform );
            }
            else
            {
                isChoosed = false;
                if (go.name == "MagicianOnChreate")
                {
                    go.GetComponent<Animation> ( ).Play ( "Idle" );

                }
                else if (go.name == "SwordmanOnChreate")
                {
                    go.GetComponent<Animation> ( ).Play ( "Sword-Idle" );
                }
            }
        }

    }

    IEnumerator CharacterMove ( GameObject go, Vector3 from, Vector3 to )
    {
        go.transform.position = Vector3.MoveTowards ( from, to, Time.deltaTime * 2 );

        yield return 0;

    }

    private void OnOkButtonClick(GameObject go){
        if (go.name == "MagicianOnChreate")
        {
            PlayerPrefs.SetInt ( "Player", 1 );

        }
        else if (go.name == "SwordmanOnChreate")
        {
            PlayerPrefs.SetInt ("Player",2 );
        }
        PlayerPrefs.SetString ( "PlayerName", playerName.value.ToString() );
        PlayerPrefs.Save ( );
        Debug.Log ( PlayerPrefs.GetString ( "PlayerName" ) );
    }
}
