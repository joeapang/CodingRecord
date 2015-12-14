using UnityEngine;
using System.Collections;

public class CreatePopupList : MonoBehaviour {

    private UIPopupList m_popup;

    public UIAtlas atlas;

    public UIFont font;

    // Use this for initialization
    void Start ( )
    {
        //层
        int depth = 0;
        //创建一个GameObject对象作为 transform.gameObject 下
        GameObject combobox = NGUITools.AddChild ( transform.gameObject );
        //给GameObject命名
        combobox.name = "Popup Script";

        //为GameObject添加挂代码UIPopupList.cs文件
        m_popup = combobox.AddComponent<UIPopupList> ( );
        //给Popup List 添加子类
        for (int i = 0; i < 5; ++i) m_popup.items.Add ( "Menu Option" + i );

        //设置Popup List 的字体大小 这个字体设置大小
        //我也不太熟悉，等以后研究会了再分享
        m_popup.fontSize = font.defaultSize;
        //设置Popup List 的字体 这里的font是通过编辑器拖拽赋值的。 
        //如果做项目应该做一个字体管理器
        m_popup.bitmapFont = font;
        //设置Popup List 被触发后弹出是否具有动画效果
        m_popup.isAnimated = false;
        //设置Popup List 的间距
        m_popup.padding = new Vector2 ( 0, 1 );
        //设置Popup List 的背景颜色
        m_popup.backgroundColor = Color.red;
        //设置Popup List 的选中颜色
        m_popup.highlightColor = Color.green;
        //设置Popup List 的纹理集
        m_popup.atlas = atlas;
        //设置Popup List 背景纹理
        m_popup.backgroundSprite = "Highlight";
        //设置Popup List 选中纹理
        m_popup.highlightSprite = "Highlight";

        //在combobox下创建一个UISprite子对象，用来作为Popup List的背景
        UISprite sprite = NGUITools.AddChild<UISprite> ( combobox );
        sprite.name = "background";
        //设置 UISprite 的纹理集
        sprite.atlas = atlas;
        //设置 UISprite 的纹理 切记名称不要搞错了，我就搞错了次，结果没有显示纹理
        sprite.spriteName = "Dark";
        //设置 UISprite 纹理的显示类型，不清楚的话，运行代码，在编辑器中设置查看
        sprite.type = UISprite.Type.Sliced;
        //设置 UISprite 的宽度 高度
        sprite.width = 150;
        sprite.height = 30;
        //设置 UISprite 层
        sprite.depth = ++depth;
        //设置 UISprite 颜色
        sprite.color = Color.green;

        //在combobox下创建一个label子对象
        UILabel label = NGUITools.AddChild<UILabel> ( combobox );
        label.name = "Label";
        label.width = 150;
        label.height = 30;
        label.bitmapFont = font;
        label.fontSize = font.defaultSize;
        label.depth = ++depth;

        //为Popup List 获取焦点的情况下加一个button 的效果 
        UIButton button = combobox.AddComponent<UIButton> ( );
        //设置 Popup List 鼠标划入时显示的颜色
        //（按钮默认效果的显示颜色是与UISprite相同的，如果想改 直接改UISprite的颜色）
        button.hover = Color.red;
        //设置 Popup List 鼠标按下时显示的效果
        button.pressed = Color.yellow;
        //设置 按钮的缓动目标
        button.tweenTarget = sprite.gameObject;

        //添加触发事件
        EventDelegate.Add ( m_popup.onChange, label.SetCurrentSelection );
        EventDelegate.Add ( m_popup.onChange, ComboboxChange );

        //添加box collider组件 这个方法可以自动帮你设置box collider 的大小
        NGUITools.AddWidgetCollider ( combobox );

        //这个方法我也不懂，如果不给他赋值，那么combobox没办法触发，
        //这个方法应该是激活该组件的意思;
        //Selection.activeObject = combobox;
        
    }

    private void ComboboxChange ( )
    {
        Debug.Log ( "ComboboxChange : " + m_popup.value );
    }

}
