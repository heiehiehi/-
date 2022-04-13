using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�洢����UI��Ϣ�������Դ�����������UI
public class UIManager
{
    public Stack<BasePanel> stack_ui;
    public Dictionary<string, GameObject> dict_uiobject;
    public GameObject CanvasObj;
    private static UIManager instance;
    //�洢����UI��Ϣ���ֵ䣬ÿһ��UI��Ϣ�����Ӧһ��GameObject
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManagerʵ��������");
            return instance;
        }
        else
        {
            return instance;
        }
    }
    public UIManager()
    {
        instance = this;
        stack_ui = new Stack<BasePanel>();
        dict_uiobject = new Dictionary<string, GameObject>();
       
    }
    public GameObject GetSingleObject(UIType uIType)
    {
        if (dict_uiobject.ContainsKey(uIType.Name))
        {
            return dict_uiobject[uIType.Name];
        }
        if (CanvasObj == null)
        {
            CanvasObj = UIMehod.GetInstance().FindCanvas();
        }
        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uIType.Path),CanvasObj.transform);
        return gameObject;
    }
    public void Push(BasePanel basePanel)
    {
        Debug.Log($"{basePanel.uiType.Name}��ѹ��ջ");

        if (stack_ui.Count > 0)
        {
            stack_ui.Peek().OnDisable();
        }
        GameObject ui_object = GetSingleObject(basePanel.uiType);
        dict_uiobject.Add(basePanel.uiType.Name, ui_object);
        basePanel.ActiveObj = ui_object;

        if (stack_ui.Count == 0)
        {
            stack_ui.Push(basePanel);
        }
        else
        {
            if (stack_ui.Peek().uiType.Name == basePanel.uiType.Name)
            {
                stack_ui.Push(basePanel);
            }
        }
        basePanel.OnStart();
    }
    //isloadΪ��ʱ��POPȫ�� isloadΪ��ʱ��Popջ��
    public void Pop(bool isload)
    {
        if(isload == true)
        {
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uiType.Name]);
                dict_uiobject.Remove(stack_ui.Peek().uiType.Name);
                stack_ui.Pop();
                Pop(true);
            }
        }
        else
        {
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uiType.Name]);
                dict_uiobject.Remove(stack_ui.Peek().uiType.Name);
                stack_ui.Pop();
                if (stack_ui.Count > 0)
                {
                    stack_ui.Peek().OnEnable();
                }
            }
        }
    }
}
