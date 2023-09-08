using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//특정 상황에 따른 씬 넘기는 방법
//    if (Input.GetKeyDown(KeyCode.Q))
//    {
//        Managers.Scene.LoadScene(Define.Scene.Game);
//    }

public class GameScene : Scene_Base
{
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
    }
    public override void Clear()
    {

    }
}
