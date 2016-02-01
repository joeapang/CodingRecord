using UnityEngine;
using System.Collections;

/// <summary>
/// 控制主角的运动方向和运动动画
/// </summary>
public class CharacterControllerScript : MonoBehaviour
{

    public float speed = 2.0f;
    public bool isMoving = false;

    // Use this for initialization
    void Start ( )
    {
       // lookAtPos = new Vector3 ( Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z );
    }

    // Update is called once per frame
    void FixedUpdate ( )
    {

    }

    public void OnPlayMoving ( )
    {

        if (ETCInput.GetAxis ( "Horizontal" ) != 0 || ETCInput.GetAxis ( "Vertical" ) != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）
            transform.LookAt ( new Vector3 ( transform.position.x + ETCInput.GetAxis ( "Horizontal" ), transform.position.y, transform.position.z + ETCInput.GetAxis ( "Vertical" ) ) );
            ////移动玩家的位置（按朝向位置移动）
            transform.Translate ( Vector3.forward * Time.deltaTime * speed );

            isMoving = true;
        }

        if (!GameMain.instance.isRun)
        {
            transform.GetComponentInChildren<Animation> ( ).Play ( "Walk" );
        }
        else
        {
            transform.GetComponentInChildren<Animation> ( ).Play ( "Run" );
            speed = 3f;
        }
    }

    public void OnPlayMovingEnd ( )
    {
        if (ETCInput.GetAxisSpeed ( "Horizontal" ) == 0 || ETCInput.GetAxisSpeed ( "Vertical" ) == 0)
        {
            isMoving = false;
        }
        transform.GetComponentInChildren<Animation> ( ).Play ( "Idle" );
    }
}
