using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject obj) where T : UnityEngine.Component
    {
        T component = obj.GetComponent<T>();
        if (component == null)
            component = obj.AddComponent<T>();
        
        return component;
    }

    public static GameObject FindChild(GameObject obj, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(obj, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (obj == null)
            return null;

        if(recursive == false)
        {
            for(int i=0; i<obj.transform.childCount; i++)
            {
                Transform transform = obj.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach(T component in obj.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }


}
