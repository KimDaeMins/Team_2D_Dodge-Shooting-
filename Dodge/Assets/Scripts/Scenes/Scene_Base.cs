using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Scene_Base : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Sample;
    void Start()
    {

    }

    protected virtual void Init()
    {
        //Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        //if (obj == null)
        //    Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
    }

    public abstract void Clear();
}
