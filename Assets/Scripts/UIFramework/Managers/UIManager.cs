using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�洢����UI��Ϣ�������Դ�����������UI
public class UIManager
{
    //�洢����UI��Ϣ���ֵ䣬ÿһ��UI��Ϣ�����Ӧһ��GameObject
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
            Debug.LogError("Canvas������");
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
