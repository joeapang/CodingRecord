using UnityEngine;
using System.Collections;

public class KnapsackManager : MonoBehaviour
{


    public GameObject[] cells;
    GameObject item;
    void Update ( )
    {
        if (Input.GetKeyDown ( KeyCode.Space ))
        {
            Debug.Log ( "space" );
            PickUp ( );
        }
    }

    //模拟拾取物品
    public string[] ItemName;
    public void PickUp ( )
    {
        item = Resources.Load ( "Knapsack_item" ) as GameObject;//加载Prefabs
        GameObject go= GameObject.Instantiate ( item ) as GameObject;//实例化Prefabs
        for(int i=0;i<cells.Length;i++){
            if (cells[i].transform.childCount == 0) {
                
                go.transform.parent = cells[i].transform;
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                break;

            }
        }
        
        

    }
}
