using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScene : Scene_Base
{
    public Animator _mainFlyAnim;
    public Camera _camera;
    private bool _introEnded = false;
    void Start()
    {
        Init();
    }

    private void ActiveStartButton()
    {
        GameObject.Find("GameStart").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void MainAnimEnded()
    {
        Invoke("ActiveStartButton" , 1.0f);
    }
    public void OnGameStart()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Logo;
    }
    public override void Clear()
    {

    }

    private void Update()
    {
        if (!_introEnded)
        {
            AnimatorStateInfo stateInfo = _mainFlyAnim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                MainAnimEnded();
                _introEnded = true;
            }
            if(stateInfo.normalizedTime >  0.8f)
            {
                Camera.main.orthographicSize = 0.5f + (1f - stateInfo.normalizedTime) * 5 * 4.5f;
            }
        }

    }
}

