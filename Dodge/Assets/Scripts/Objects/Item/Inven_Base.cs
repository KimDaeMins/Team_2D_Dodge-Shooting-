using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inven_Base
{
    private string _name;
    public string Name { get => _name; }
    public int Count { get; set; } = 1;

    private int _maxCount;
    public int MaxCount { get => _maxCount; }

    public Sprite _sprite;
    public abstract void UseItem();
    public void InitItem(string name , int maxCount)
    {
        _name = name;
        Managers.Resource.LoadSprite(name);
        _maxCount = maxCount;
    }
}
