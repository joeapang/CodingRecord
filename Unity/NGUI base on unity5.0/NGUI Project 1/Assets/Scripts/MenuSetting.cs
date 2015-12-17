using UnityEngine;
using System.Collections;

public class MenuSetting : MonoBehaviour
{

    public enum GameGrade
    {
        Difficulty,
        Normal,
        Easy
    }   


    public enum ControlType
    {
        KeyBorad,
        Touch,
        Mouse
    }


    public static float volume = 1;

    public static GameGrade grade = GameGrade.Normal;
    public static ControlType controlType = ControlType.Touch;
    public static bool isFullScreen = false;


    public void OnVolumeChanged ( ) {
        Debug.Log ("Volum:"+UIProgressBar.current.value);
    }
    public void OnGradeChanged ( ) {
        Debug.Log ( "Grade:" + UIPopupList.current.value );
    }

    public void OnControlTypeChange ( ) {
        Debug.Log ( "ControlType:"+UIPopupList.current.value);
    }

    public void OnIsFullChanged ( ) {
        Debug.Log ( "IsFull:" + UIToggle.current.value );
    }
}
