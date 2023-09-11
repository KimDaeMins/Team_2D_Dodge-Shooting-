using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : Scene_Base
{
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Sample;
    }
    public override void Clear()
    {

    }
}
