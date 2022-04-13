using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����UI���ĸ��࣬����UI����״̬��Ϣ
public class BasePanel
{
    public UIType uiType;

    public GameObject ActiveObj;

    public BasePanel(UIType uitype)
    {
        uiType = uitype;
    }
    //UI�����ʱ��ִ�еĲ���
    public virtual void OnStart() { 
        Debug.Log($"{uiType.Name}��ʼʹ��");
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    //UI��ͣʱִ�еĲ���
    public virtual void OnEnable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    //UI������ʱ��ִ�еĲ���
    public virtual void OnDisable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;

    }
    //UI�˳���ʱ��ִ�еĲ���
    public virtual void OnDestroy()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    
}
