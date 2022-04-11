using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//所有UI面板的父类，包含UI面板的状态信息
public abstract class BasePanel
{
    public UIType UIType { get; private set; }

    public BasePanel(UIType uIType)
    {
        UIType = UIType;
    }
    //UI进入的时候执行的操作
    public virtual void OnEnter() { }
    //UI暂停时执行的操作
    public virtual void OnPause()
    {

    }
    //UI继续的时候执行的操作
    public virtual void OnResume()
    {

    }
    //UI退出的时候执行的操作
    public virtual void OnExit()
    {

    }

    
}
