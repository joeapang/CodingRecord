using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float speed = 1.0f;
    void Update ( ) {
        float translation = ETCInput.GetAxis ( "Vertical" ) * speed;
        float roation = ETCInput.GetAxis ( "Horizontal" ) * speed;
        translation *= Time.deltaTime;
        roation *= Time.deltaTime;
        transform.Translate (translation,roation,0 );
    }
    public void OnJoystickMove ( ) { 
    }
}
