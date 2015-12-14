using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {



    public GameObject startButton;
    public GameObject optionButton;
    public GameObject exitButton;


    public void activeButton ( ) {


        startButton.SetActive ( true );
        optionButton.SetActive ( true );
        exitButton.SetActive ( true );
    }


}
