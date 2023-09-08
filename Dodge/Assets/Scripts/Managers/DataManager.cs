using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DataManager
{
    public Sprite UserSprite { get; set; }
    public RuntimeAnimatorController AnimatorController { get; set; }

    public Dictionary<string , Item> items = new Dictionary<string , Item>();
    public void Init()
    {
        //UserSprite = Managers.Resource.LoadSprite("elf");
    }

    public bool UseItem(string name)
    {
        if (items.ContainsKey(name) == false)
        {
            return false;
        }
        if (items[name].Count == 0)
        {
            return false;
        }

        items[name].Count -= 1;

        return true;
    }

    public void GetItem(string name)
    {
        Item item = items[name];
    }
    public void GetItem(Item item)
    {
    }
}