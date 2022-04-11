using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanlManager : MonoBehaviour
{
    //�洢UI����ջ
    private Stack<BasePanel> stackPanel;
    //UI������
    private UIManager uIManager;
    private BasePanel panel;
    // Start is called before the first frame update
    public PanlManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManager = new UIManager();
    }

    //ִ��������ջ�������ѵ�ǰջ����ͣ
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

    //ִ������ջ���������������ִ������OnExit����
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
