using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanlManager : MonoBehaviour
{
    //存储UI面板的栈
    private Stack<BasePanel> stackPanel;
    //UI管理器
    private UIManager uIManager;
    private BasePanel panel;
    // Start is called before the first frame update
    public PanlManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManager = new UIManager();
    }

    //执行面板的入栈操作，把当前栈给暂停
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }
        stackPanel.Push(nextPanel);
        GameObject panelGO = uIManager.GetSingleUI(nextPanel.UIType);
    }

    //执行面板出栈操作，这个操作会执行面板的OnExit方法
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnResume();
        }
    }
}
