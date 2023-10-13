using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_PopUp
{
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    { 
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        {
            GameObject obj = GetButton((int)Buttons.PointButton).gameObject;
            AddUIEvent(obj, OnButtonClicked);
        }
        {
            GameObject obj = GetImage((int)Images.ItemIcon).gameObject;
            AddUIEvent(obj, (PointerEventData data) => { obj.gameObject.transform.position = data.position; }, Define.UIEvent.Drag);
        }
    }


    int _score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"Score: {_score} ";
    }

}

