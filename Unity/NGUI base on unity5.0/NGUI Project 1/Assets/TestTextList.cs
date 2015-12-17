using UnityEngine;
using System.Collections;

public class TestTextList : MonoBehaviour {

    public UITextList textList;
    public UIInput lable;

    void Update ( ) {
       // Debug.Log ( lable.value);
    }
	// Update is called once per frame
	public void SetText () {
        Debug.Log ( "11" );
     
        textList.Add ( lable.value.ToString() );
        lable.value = "";
	}
}
