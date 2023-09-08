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
        CurrentScene.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        //규칙을 추가 하거나 할 수 있기때문에 이런식으로 따로 빼는게 좋다
        //return Util.GetDefineName<Define.Scene>(type);
        //타입이 거의 정해져있어서 이런식으로 써도 문제는 없겠다만 위에꺼가 조금 더 안전할듯
        return Util.GetDefineName(type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
