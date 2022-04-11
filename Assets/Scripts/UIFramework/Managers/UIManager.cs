using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储所有UI信息，并可以创建或者销毁UI
public class UIManager
{
    //存储所有UI信息的字典，每一个UI信息都会对应一个GameObject
    private Dictionary<UIType, GameObject> dicUI;

    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvans");
        if (!parent)
        {
            Debug.LogError("Canvas不存在");
            return null;
        }
        if (dicUI.ContainsKey(type))
            return dicUI[type];
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        ui.name = type.Name;
        return ui;
    }
    public void DestoryUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
            dicUI.Remove(type);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
