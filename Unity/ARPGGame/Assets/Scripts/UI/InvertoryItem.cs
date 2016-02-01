using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;

/// <summary>
/// 处理物品的拖拽和物品信息
/// </summary>
public class InvertoryItem : UIDragDropItem {

    ObjectPro item = null;
    //UISprite iconSprite;

    void Awake ( ) {
        base.Awake ( );
       // iconSprite = GetComponent<UISprite> ( );
    }


    protected override void OnDragDropStart ( )
    {
        base.OnDragDropStart ( );
    }
    /// <summary>
    /// 物品拖拽操作
    /// </summary>
    /// <param name="surface"></param>
    protected override void OnDragDropRelease ( GameObject surface )
    {
        base.OnDragDropRelease ( surface );
        
        if (surface != null)
        {
            if (surface.tag == "Box")
            {

                InventoryItemGrid oldparent = this.transform.parent.GetComponent<InventoryItemGrid> ( );
                this.transform.parent = surface.transform;
                ResetPos ( this.gameObject );
                InventoryItemGrid newParent = surface.GetComponent<InventoryItemGrid> ( );
                newParent.SetInfo ( oldparent.itemIdSaved, oldparent.count );
                oldparent.ClearInfo ( );
            }
            else if (surface.tag == "Item") {
                GameObject temp=transform.parent.gameObject;
                InventoryItemGrid firstParent = this.transform.parent.GetComponent<InventoryItemGrid> ( );
                InventoryItemGrid targetParent = surface.transform.parent.GetComponent<InventoryItemGrid> ( );
                this.transform.parent = surface.transform.parent;
                surface.transform.parent = temp.transform;
                ResetPos ( surface.gameObject );
                ResetPos ( transform.gameObject );

                InventoryItemGrid tempInfo = new InventoryItemGrid ( );
                tempInfo.itemIdSaved = firstParent.itemIdSaved;
                tempInfo.count = firstParent.count;
                firstParent.SetInfo ( targetParent.itemIdSaved, targetParent.count );
                targetParent.SetInfo ( tempInfo.itemIdSaved, tempInfo.count );
                //InventoryItemGrid newParent = surface.transform.GetComponent<InventoryItemGrid> ( );
                //newParent.SetInfo ( oldparent.itemIdSaved, oldparent.count );
                //oldparent.ClearInfo ( );
            }
        }
    }

    public ObjectPro GetItemInfo ( int id )
    {
        item = ObjectData.instance.GetObjectById ( id );
        return item;
    }
    public void ResetPos (GameObject tran ) {
        tran.transform.localPosition = Vector3.zero;
        tran.transform.localScale = Vector3.one;
    }
}
