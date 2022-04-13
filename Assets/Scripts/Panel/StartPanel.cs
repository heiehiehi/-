using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "Prefabs/UI/Panel/StartPanel";
    public static UIType uIType = new UIType(path,name);
    public StartPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "news").onClick.AddListener(News);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "introduce").onClick.AddListener(Introduce);
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "shop").onClick.AddListener(Shop);
    }
    private void News()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new NewsPanel());
    }
    private void Introduce()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new IntroducePanel());
    }
    private void Shop()
    {
        GameRoot.GetInstance().UIManager_Root.Push(new ShopPanel());
    }
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
