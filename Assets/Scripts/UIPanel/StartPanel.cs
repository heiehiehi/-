using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "Prefebs/UI/Panel/StartPanel";
    public static readonly UIType uIType = new UIType(path,name);
    public StartPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
