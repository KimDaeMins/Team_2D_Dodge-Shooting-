using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX
{
    public Scene_Base CurrentScene
    {
        get
        {
            return GameObject.FindObjectOfType<Scene_Base>();
        }
    }
    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        //CurrentScene.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        return Util.GetDefineName<Define.Scene>(type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
