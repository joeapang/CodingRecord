using UnityEngine;
using System.Collections;

public class PasswordLimit : MonoBehaviour {

	public UIInput passwordInput;
    public UILabel Tip;


	public void getInputValue ( ) {
        Debug.Log ( "Changes" );
       int pswLength = passwordInput.value.Length;
       Debug.Log ( pswLength );
       if (pswLength < 6 || pswLength > 16)
       {
           Tip.transform.gameObject.SetActive( true);
       }
       else {
           Tip.transform.gameObject.SetActive ( false );
       }
	}
}
