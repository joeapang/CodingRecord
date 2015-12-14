using UnityEngine;
using System.Collections;

public class SetText : MonoBehaviour {

    public UIPopupList pop;

    void Update(){
        if (pop.value != null)
        {
            GetComponent<UILabel>().text= pop.isLocalized?
                Localization.Get ( pop.value ) :
                pop.value;
            Debug.Log ( pop.value );
        }
    }
}
