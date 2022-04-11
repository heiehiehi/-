using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����UI���ĸ��࣬����UI����״̬��Ϣ
public abstract class BasePanel
{
    public UIType UIType { get; private set; }

    public BasePanel(UIType uIType)
    {
        UIType = UIType;
    }
    //UI�����ʱ��ִ�еĲ���
    public virtual void OnEnter() { }
    //UI��ͣʱִ�еĲ���
    public virtual void OnPause()
    {

    }
    //UI������ʱ��ִ�еĲ���
    public virtual void OnResume()
    {

    }
    //UI�˳���ʱ��ִ�еĲ���
    public virtual void OnExit()
    {

    }

    
}
