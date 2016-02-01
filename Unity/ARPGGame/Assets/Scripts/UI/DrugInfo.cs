using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Game;
public class DrugInfo : MonoBehaviour
{

    public Image icon;
    public Text name;
    public Text price_sell;

    // Use this for initialization
    void Start ( )
    {
        // UpdateDrugInfo ( );

    }


    public void UpdateDrugInfo ( ObjectPro item )
    {
        Sprite sp = Resources.Load ( "RPG/Sprites/Icon/1"+item.icon_name,typeof(Sprite)) as Sprite;
     
        
        //Instantiate ( sp);
        icon.overrideSprite = sp;
        name.text = "名称：" + item.name.ToString ( );
        price_sell.text = "售价" + item.price_sell.ToString ( );

    }


}
