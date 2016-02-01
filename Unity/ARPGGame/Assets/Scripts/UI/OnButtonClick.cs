using UnityEngine;
using System.Collections;

public class OnButtonClick : MonoBehaviour
{

    public GameObject loadGameBtn;
    public GameObject newGameBtn;
    public GameObject tapToStart;
    void Awake ( )
    {
        UIEventListener.Get ( loadGameBtn ).onClick = OnButtonClicked;
        UIEventListener.Get ( newGameBtn ).onClick = OnButtonClicked;
        UIEventListener.Get ( tapToStart ).onClick = OnButtonClicked;
    }

    void Start ( )
    {

    }


    private void OnButtonClicked ( GameObject button )
    {
        Debug.Log ( button.name );
        if (button.gameObject.name == "TapToStart")
        {
            button.SetActive ( false );
            newGameBtn.SetActive ( true );
            loadGameBtn.SetActive ( true );

        }
        else if (button.name == "LoadGameBtn")
        {
            PlayerPrefs.SetInt ( "GameData", 0 );
            AudioseBase.instance.GetComponent<AudioSource> ( ).PlayOneShot ( AudioseBase.instance.button);
        }
        else if (button.name == "NewGameBtn")
        {
            PlayerPrefs.SetInt ( "GameData", 1 );
            AudioseBase.instance.GetComponent<AudioSource> ( ).PlayOneShot ( AudioseBase.instance.button );
        }
    }
}
