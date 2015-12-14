using UnityEngine;
using System.Collections;

public class SkillCD : MonoBehaviour
{


    public UISprite CDSprite;
    public float CDTime = 2;
    public float Timer = 0;
    public bool isCd = false;
    // public float CDFillAmount;

    // Use this for initialization
    void Start ( )
    {
        //CDSprite.fillAmount = 0.0f;
        //CDFillAmount = CDSprite.fillAmount;
    }

    // Update is called once per frame
    void Update ( )
    {
        if (Input.GetKeyDown ( KeyCode.A ))
        {
            Debug.Log ( "in:" );
            CDSprite.fillAmount = 1.0f;
            isCd = true;

        }
        //Debug.Log ( Time.time );

        if (isCd == true)
        {
           
            CDSprite.fillAmount = Mathf.MoveTowards( CDSprite.fillAmount, 0.0f, Time.deltaTime/2 );
            Timer += Time.deltaTime;
            if (CDSprite.fillAmount == 0) {
                isCd = false;
                Timer = 0;
            }
        }
        Debug.Log ( Timer );
    }
}
