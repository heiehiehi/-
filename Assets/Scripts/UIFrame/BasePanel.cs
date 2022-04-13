using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//所有UI面板的父类，包含UI面板的状态信息
public class BasePanel
{
    public UIType uiType;

    public GameObject ActiveObj;

    public BasePanel(UIType uitype)
    {
        uiType = uitype;
    }
    //UI进入的时候执行的操作
    public virtual void OnStart() { 
        Debug.Log($"{uiType.Name}开始使用");
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    //UI暂停时执行的操作
    public virtual void OnEnable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    //UI继续的时候执行的操作
    public virtual void OnDisable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;

    }
    //UI退出的时候执行的操作
    public virtual void OnDestroy()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    
}
