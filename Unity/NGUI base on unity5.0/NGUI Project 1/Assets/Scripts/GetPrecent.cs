using UnityEngine;
using System.Collections;

public class GetPrecent : MonoBehaviour {

    UISlider slider;
    public GameObject back;
    UILabel lable;

    void Start ( ) {
        slider = back.GetComponent<UISlider> ( );
        lable= this.GetComponent<UILabel> ( );
     
    }

    void Update ( ) {
         lable.text= slider.value*100 +"%";
    }

}
