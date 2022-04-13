using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private UIManager UIManager;
    public UIManager UIManager_Root
    {
        get => UIManager;
    }
    private SceneControl SceneControl;
    public SceneControl SceneControl_Root
    {
        get => SceneControl;
    }

    private static GameRoot instance;
    public static GameRoot GetInstacne()
    {
        if(instance == null)
        {
            Debug.LogError("CameRoot���ʵ��ʧ��");
            return instance;
        }
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        UIManager = new UIManager();
        SceneControl = new SceneControl();
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager_Root.CanvasObj = UIMehod.GetInstance().FindCanvas();

        //����һ�����
        UIManager_Root.Push(new StartPanel());
        
    }
}
