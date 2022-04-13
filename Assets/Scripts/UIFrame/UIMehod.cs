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
            Debug.LogError("û���ڳ��������ҵ�Canvas");
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
        Debug.LogWarning($"��{panel.name}���嵱��û���ҵ�{child_name}����");
        return null;
    }
    public T AddOrGetComponent<T>(GameObject Get_Obj) where T : Component
    {
        if (Get_Obj.GetComponent<T>() != null)
        {
            return Get_Obj.GetComponent<T>();
        }

        Debug.LogWarning($"�޷���{Get_Obj}�����ϻ��Ŀ�������");
        return null;
    }

    /// <summary>
    ///��Ŀ��Panel���������У���������������ƻ�ö�Ӧ��� 
    /// </summary>
    /// <typeparam name="T">��Ӧ���</typeparam>
    /// <param name="panel">Ŀ��Panel</param>
    /// <param name="ComponentName">����������</param>
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

        Debug.LogWarning($"û����{panel.name}���ҵ�{ComponentName}���壡");
        return null;
    }
}
