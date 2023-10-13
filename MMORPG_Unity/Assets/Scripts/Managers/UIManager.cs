using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    int _order = 10;

    // LIFO
    Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public void SetCanvas(GameObject obj, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(obj);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject obj = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(obj);
        _sceneUI = sceneUI;

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null)
            root = new GameObject { name = "@UI_Root" };

        obj.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopUpUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject obj = Managers.Resource.Instantiate($"UI/PopUp/{name}");
        T popup =  Util.GetOrAddComponent<T>(obj);
        _popupStack.Push(popup);

        obj.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopUpUI(UI_PopUp popup)
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
