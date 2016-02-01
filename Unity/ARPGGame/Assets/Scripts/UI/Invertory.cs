using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 对整个背包系统进行管理
/// </summary>
public class Invertory : MonoBehaviour
{

    public static Invertory instance;
    public List<InventoryItemGrid> InvertoryItem = new List<InventoryItemGrid> ( );
    public UILabel coinLable;

    void Awake ( )
    {
        instance = this;
    }

    void Update ( )
    {
        CreateItemById ( );
        CreateItemById ( 1002 );
    }
    /// <summary>
    /// 创建物品，默认数量为1
    /// </summary>
    /// <param name="id"></param>
    /// <param name="count"></param>
    void CreateItemById ( int id = 1001, int count = 1 )
    {
        int index = -1;
        if (!isExitsThisItem ( id, out index ))
        {
            GameObject item = Resources.Load ( "Prefabs/UI/Invertory_item" ) as GameObject;
            GameObject go = Instantiate ( item, Vector3.zero, Quaternion.identity ) as GameObject;
            InvertoryItem[index].SetInfo ( id, count );
            InvertoryItem[index].itemIsCreating = go.GetComponent<InvertoryItem> ( ).GetItemInfo ( id );
            go.GetComponent<UISprite> ( ).spriteName = InvertoryItem[index].itemIsCreating.icon_name;
            go.transform.parent = InvertoryItem[index].objslf.transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;

        }
        else
        {
            InvertoryItem[index].count++;
            InvertoryItem[index].countLable.text = InvertoryItem[index].count.ToString ( );
        }
    }


    /// <summary>
    /// 判断物品是否存在，如果存在count加1，如果不存在这得到下标最小的空格子
    /// </summary>
    /// <param name="id"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool isExitsThisItem ( int id, out int index )
    {
        List<InventoryItemGrid> temp = Invertory.instance.InvertoryItem;
        int j = 0;
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].itemIsCreating == null)
            {
                j = i;
                break;
            }
            else if (temp[i].itemIsCreating.id == id)
            {
                index = i;
                return true;
            }

        }
        index = j;
        return false;
    }
}
