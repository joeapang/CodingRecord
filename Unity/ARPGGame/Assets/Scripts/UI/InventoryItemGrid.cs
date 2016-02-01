using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;
using System.Collections.Generic;


/// <summary>
/// 对背包系统中的方格进行管理
/// </summary>
public class InventoryItemGrid : MonoBehaviour
{


    public UILabel countLable;
    public int count;
    public ObjectPro itemIsCreating = null;//正在创建的物品
    public int itemIdSaved;//已经放置物品的id
    public GameObject objslf;
    void Awake ( )
    {
        objslf = this.transform.gameObject;
        countLable = this.transform.FindChild ( "Count" ).transform.GetComponent<UILabel> ( );

    }
    void Start ( )
    {
        
    }

    public void SetInfo ( int id,int count) {
        itemIdSaved = id;
        this.count = count;
        countLable.text = count.ToString ( );
        countLable.gameObject.SetActive ( true);
    }

    public void ClearInfo ( ) {
        itemIdSaved = 0;
        count = 0;
        countLable.gameObject.SetActive ( false );
    }

}
