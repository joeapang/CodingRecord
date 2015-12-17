using UnityEngine;
using System.Collections;

public class ColliderAdapt : MonoBehaviour {

    public BoxCollider boxCollider;
    public UIWidget widget;

    void Awake ( ) {
        boxCollider = transform.GetComponent<BoxCollider> ( );
    }

    void Resize ( ) {
        boxCollider.size = widget.localSize;
       // boxCollider.size.y = widget.localSize.y;
    }
}
