using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMehod
{
    private static UIMehod instance;

    public static UIMehod GetInstance()
    {
        if(instance == null)
        {
            instance = new UIMehod();
        }
        return instance;
    }

    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(gameObject == null)
        {
            Debug.LogError("没有在场景里面找到Canvas");
            return gameObject;
        }
        return gameObject;
    }
    public GameObject FindObjectInChild(GameObject panel,string child_name)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (var tra in transforms)
        {
            if (tra.gameObject.name == child_name)
            {
                return tra.gameObject;
            }
        }
        Debug.LogWarning($"在{panel.name}物体当中没有找到{child_name}物体");
        return null;
    }
    public T AddOrGetComponent<T>(GameObject Get_Obj) where T : Component
    {
        if (Get_Obj.GetComponent<T>() != null)
        {
            return Get_Obj.GetComponent<T>();
        }

        Debug.LogWarning($"无法在{Get_Obj}物体上获得目标组件！");
        return null;
    }

    /// <summary>
    ///从目标Panel的子物体中，根据子物体的名称获得对应组件 
    /// </summary>
    /// <typeparam name="T">对应组件</typeparam>
    /// <param name="panel">目标Panel</param>
    /// <param name="ComponentName">子物体名称</param>
    /// <returns></returns>

    public T GetOrAddSingleComponentInChild<T>(GameObject panel, string ComponentName) where T : Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform tra in transforms)
        {
            if (tra.gameObject.name == ComponentName)
            {
                return tra.gameObject.GetComponent<T>();
                break;
            }
        }

        Debug.LogWarning($"没有在{panel.name}中找到{ComponentName}物体！");
        return null;
    }
}
