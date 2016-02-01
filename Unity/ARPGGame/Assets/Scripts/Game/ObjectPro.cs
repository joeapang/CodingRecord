using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// 储存物品的属性
    /// </summary>
    public class ObjectPro
    {
        public int id;//物品的ID，药品以100开头，装备以200开头，材料以300开头
        public string name;//物品名称
        public string icon_name;//物品的图标名称
        public ObjectType type = ObjectType.Drug;//物品种类
        public int hp;//药品加的血量
        public int mp;//药品加的蓝量
        public int price_sell;//物品出售价
        public int price_buy;//物品购买价


        public ObjectPro ( )
        {
            id = 0;
            name = null;
            icon_name = null;
            hp = 0;
            mp = 0;
            price_buy = 0;
            price_sell = 0;
        }
    }
}
