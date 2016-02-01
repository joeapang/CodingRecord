using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;
using System.Collections.Generic;
public enum ObjectType
{
    Drug,//药品
    Equip,//装备
    Mat//材料
}

public class ObjectData : MonoBehaviour
{
    public static ObjectData instance;

    private Dictionary<int, ObjectPro> objectDict = new Dictionary<int, ObjectPro> ( );//以键值对的形式存储物品
    public List<ObjectPro> drugList = new List<ObjectPro>();//以键值对的形式存储药品
    //public ObjectPro objectInfo = new ObjectPro ( );
    // Use this for initialization
    void Awake ( )
    {
        instance = this;
        LoadObjectDataFromLocal ( );
        

    }

    public bool LoadObjectDataFromLocal ( )
    {

        TextAsset objectText = Resources.Load ( "Text/Object/OjbectsInfoList" ) as TextAsset;
        if (objectText == null)
        {
            objectText = Resources.Load ( "Text/Object/OjbectsInfoList" ) as TextAsset;
        }

        ProcessObjectDataFromString ( objectText.text );
        return true;
    }


    /// <summary>
    /// 解析文档中的物品信息
    /// </summary>
    /// <param name="objectText"></param>
    private void ProcessObjectDataFromString ( string objectText )
    {
        //药品每行依次是：id, name, icon_name, ObjectType, hp, mp, price_sell, price_buy
        string[] lines = objectText.Split ( new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries );
        foreach (string line in lines)
        {
            string temp = line.Trim ( );
            string[] proArry = temp.Split ( new string[] { "," }, System.StringSplitOptions.RemoveEmptyEntries );
            ObjectPro objectInfo = new ObjectPro ( );
            objectInfo.id = int.Parse ( proArry[0] );
            objectInfo.name = proArry[1];
            objectInfo.icon_name = proArry[2];
            switch (proArry[3])
            {
                case "Drug":
                    objectInfo.type = ObjectType.Drug;
                    objectInfo.hp = int.Parse ( proArry[4] );
                    objectInfo.mp = int.Parse ( proArry[5] );
                    objectInfo.price_sell = int.Parse ( proArry[6] );
                    objectInfo.price_buy = int.Parse ( (proArry[7].Trim ( )) );
                    drugList.Add (objectInfo );
                    break;
                case "Equip":
                    objectInfo.type = ObjectType.Equip;
                    break;
                case "Mat":
                    objectInfo.type = ObjectType.Mat;
                    break;
            }


            
            objectDict.Add ( objectInfo.id, objectInfo );//添加到字典中，以Id为Key
        }

    }
    /// <summary>
    /// 通过Id的到物品
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ObjectPro GetObjectById ( int id )
    {
        ObjectPro obj = null;
        objectDict.TryGetValue( id, out obj );
        return obj;
    }


}
