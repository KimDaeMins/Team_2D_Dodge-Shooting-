using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');

            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path , Vector3 pos)
    {
        return Instantiate(path , pos , Quaternion.identity);
    }
    public GameObject Instantiate(string path , Vector3 pos , Vector3 rotation)
    {
        Quaternion q = Quaternion.Euler(rotation);

        return Instantiate(path , pos , q);
    }
    public GameObject Instantiate(string path , Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load original : {path}");
            return null;
        }


        GameObject go;
        if (original.TryGetComponent<Poolable>(out Poolable p))
        {
            go = Managers.Pool.Pop(original , parent).gameObject;
            if (go.TryGetComponent<Object_Base>(out Object_Base oo))
                Managers.Object.Add(go , oo.ObejctType);
            return go;
        }

        go = Object.Instantiate(original , parent);
        go.name = original.name;

        if (go.TryGetComponent<Object_Base>(out Object_Base o))
            Managers.Object.Add(go , o.ObejctType);

        return go;
    }
    public GameObject Instantiate(string path , Vector3 pos , Quaternion q , Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load original : {path}");
            return null;
        }

        GameObject go;
        if (original.TryGetComponent<Poolable>(out Poolable p))
        {
            go = Managers.Pool.Pop(original , pos , q , parent).gameObject;
            if (go.TryGetComponent<Object_Base>(out Object_Base oo))
                Managers.Object.Add(go , oo.ObejctType);
            return go;
        }

        
        if (parent == null)
            go = Object.Instantiate(original , pos , q);
        else
            go = Object.Instantiate(original , pos , q , parent);
        go.name = original.name;

        if (go.TryGetComponent<Object_Base>(out Object_Base o))
            Managers.Object.Add(go , o.ObejctType);

        return go;
    }



    public Sprite LoadSprite(string path)
    {
        Sprite sprite = Load<Sprite>($"Arts/Sprites/{path}");
        return sprite;
    }
    public RuntimeAnimatorController LoadAnimatorController(string path)
    {
        RuntimeAnimatorController anim = Load<RuntimeAnimatorController>($"Animations/{path}");
        return anim;
    }
    public void Destroy(GameObject go , float t = 0.0f)
    {
        if (go == null)
            return;

        //Poolable poolable = go.GetComponent<Poolable>();
        //if (poolable != null)
        //{
        //    Managers.Pool.Push(poolable);
        //    return;
        //}
        if (go.TryGetComponent<Object_Base>(out Object_Base o))
            Managers.Object.Remove(go , o.ObejctType);
        if (go.TryGetComponent<Poolable>(out Poolable p))
        {
            Managers.Pool.Push(p);
            return;
        }
        Object.Destroy(go , t);
        go = null;
    }
    public void Destroy(MonoBehaviour mob , float t = 0.0f)
    {
        Destroy(mob.gameObject , t);
        mob = null;
    }
}
