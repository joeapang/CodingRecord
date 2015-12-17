using UnityEngine;
using System.Collections;

public class KnapsackItem :UIDragDropItem {

    protected override void OnDragDropStart ( )
    {
        base.OnDragDropStart ( );
        //设置物品的深度，防止拖拽时被遮挡
        this.transform.GetComponent<UISprite> ( ).depth = 4;
    }


    //重写OnDragDropRelease方法，实现物品的位置交换
    protected override void OnDragDropRelease ( GameObject surface )
    {
        base.OnDragDropRelease ( surface );
        //如果是cell，说明格子是空的
        if (surface.tag == "Cell")
        {
            this.transform.parent = surface.transform;
            this.transform.localPosition = Vector3.zero;
        }
        //如果是Knapsack_item，说明格子中存在物品
        if (surface.tag == "Knapsack_item") {
            Transform tempParent = surface.transform.parent;
            surface.transform.parent=this.transform.parent;
            surface.transform.localPosition = Vector3.zero;
            this.transform.parent = tempParent;
            this.transform.localPosition = Vector3.zero;

        }
        //重置物品的深度
        this.transform.GetComponent<UISprite> ( ).depth = 3;
        
    }



}
