using UnityEngine;
using System.Collections;
using System;


public delegate void ResizeEventHandler ( object sender, ResizeObject args );
public class ResizeListener : MonoBehaviour {

    public event ResizeEventHandler ResizeEvent;

    public float oldWidth;
    public float oldHight;

    public float width;
    public float hight;
    public  UIWidget widget;
    ResizeObject o ;
	// Use this for initialization
	void Start () {
        oldWidth = widget.localSize.x;
        oldHight = widget.localSize.y;
        o = new ResizeObject ( );
	}
	
	// Update is called once per frame
	void Update () {
        width = widget.localSize.x;
        hight = widget.localSize.y;
        
        if (isSizeChanged (o)) {
            Listener ( o );
        }
	}

    public bool isSizeChanged(ResizeObject o) {
        if (oldHight != hight || oldWidth != width) {
           
            return true;
        }
        return false;
    }

    public void Listener ( ResizeObject o ) {
        ResizeEvent += ResizeListener_ResizeEvent;
        OnResize ( o );
    }
    void ResizeListener_ResizeEvent ( object sender, ResizeObject args )
    {
        
        SendMessage ( "Resize" );
    }

    public virtual void OnResize ( ResizeObject args )
    {
        if (ResizeEvent!=null) {
            ResizeEvent ( this, args );
        }
    }
}
