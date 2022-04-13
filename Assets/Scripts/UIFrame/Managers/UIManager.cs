using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储所有UI信息，并可以创建或者销毁UI
public class UIManager
{
    public Stack<BasePanel> stack_ui;
    public Dictionary<string, GameObject> dict_uiobject;
    public GameObject CanvasObj;
    private static UIManager instance;
    //存储所有UI信息的字典，每一个UI信息都会对应一个GameObject
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManager实例不存在");
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
        Debug.Log($"{basePanel.uiType.Name}被压入栈");

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
    //isload为真时，POP全部 isload为假时，Pop栈顶
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
