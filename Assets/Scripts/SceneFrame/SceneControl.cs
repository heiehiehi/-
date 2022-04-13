using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl
{
    public Dictionary<string, SceneBase> dict_scene;
    private static SceneControl instance;
    private static SceneControl GetInstance()
    {
        if(instance == null)
        {
            Debug.LogError("SceneControlʵ�岻����");
            return instance;
        }
        return instance;
    }
    //����һ������
    public void LoadScene(string scene_name,SceneBase sceneBase)
    {
        if (!dict_scene.ContainsKey(scene_name))
        {
            dict_scene.Add(scene_name, sceneBase);
        }
        if (dict_scene.ContainsKey(SceneManager.GetActiveScene().name))
        {
            dict_scene[SceneManager.GetActiveScene().name].ExitScene();
        }
        else
        {
            Debug.LogWarning($"SceneControl���ֵ��в�����{SceneManager.GetActiveScene().name}!");
        }

        GameRoot.GetInstacne().UIManager_Root.Pop(true);

        SceneManager.LoadScene(scene_name);
        sceneBase.EnterScene();
    }
}
