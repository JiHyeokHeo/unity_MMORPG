using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;



        for (int i = 0; i < 5; i++)
            Managers.Resource.Instantiate("UnityChan");
        //Managers.UI.ShowSceneUI<UI_Inven>();
        //Managers.UI.ShowPopUpUI<UI_Button>();
        //Managers.UI.MakeSubItem<UI_Inven_Item>();
    }

    public override void Clear()
    {

    }
}
