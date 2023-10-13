using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    int _order = 0;

    // LIFO
    Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();

    public T ShowPopUpUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject obj = Managers.Resource.Instantiate($"UI/PopUp/{name}");
        T popup =  Util.GetOrAddComponent<T>(obj);
        _popupStack.Push(popup);
        return popup;
    }

    public void ClosePupUpUI(UI_PopUp popup)
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() != popup)
        {
            Debug.Log("ClosePopup Failed");
            return;
        }

        ClosePopUpUI();
    }

    public void ClosePopUpUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_PopUp popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllAPopUpUI()
    {
        while (_popupStack.Count > 0)
            ClosePopUpUI();
    }

}
