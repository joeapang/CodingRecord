using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;

public class Shop : MonoBehaviour
{

    public static Shop instance;
    public GameObject drugInfo;
    public GameObject panel;



    void Awake ( )
    {
        instance = this;
       // panel.GetComponent<RectTransform> ( ).sizeDelta =new Vector2(0 ,80);
        panel.GetComponent<RectTransform> ( ).anchoredPosition = new Vector2 ( 0, 0 );
        
    }


    void Start ( ) {
        for (int i = 0; i < ObjectData.instance.drugList.Count;i++ )
        {
            GameObject go = Resources.Load ( "Prefabs/UI/Drug" ) as GameObject;
            GameObject drug = Instantiate ( go ) as GameObject;
            drug.GetComponent<DrugInfo> ( ).UpdateDrugInfo ( ObjectData.instance.drugList[i] );
            drug.transform.parent = panel.transform;
            drug.transform.localScale = Vector3.one;
            panel.GetComponent<RectTransform>().sizeDelta=new Vector2(panel.GetComponent<RectTransform>().sizeDelta.x,panel.GetComponent<RectTransform>().sizeDelta.y*(i+1));
           // drug.transform.localPosition = Vector3.zero-new Vector3(0, i*drug.GetComponent<RectTransform>().sizeDelta.y,0);
            drug.GetComponent<RectTransform> ( ).anchoredPosition = new Vector2(0,50)-new Vector2(0,50*(i));
            
        }

    }
    public void TransformStatus ( )
    {
        this.transform.gameObject.SetActive ( !this.transform.gameObject.activeSelf );
    }
}
