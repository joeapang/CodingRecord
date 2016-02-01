using UnityEngine;
using System.Collections;

public class MyFirstTouch : MonoBehaviour {

    void OnEnable ( ) {
        EasyTouch.On_TouchStart += On_TouchStart;
    }

    void OnDisable ( ) {
        EasyTouch.On_TouchStart -= On_TouchStart;
    }
    void OnDestory ( ) {
        EasyTouch.On_TouchStart -= On_TouchStart;
    }
    public void On_TouchStart (Gesture gesture ) {
        Debug.Log ( gesture.position);
    }
}
