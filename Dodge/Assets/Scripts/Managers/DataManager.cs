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

    public Dictionary<string, Item> _itemsDic = new Dictionary<string , Item>();
    public List<Item> _itemslist = new List<Item>();

    public void Init()
    {
        //여기서 딕셔너리랑 리스트에 아이템을 전부 넣어준다
        //Item item = new Item();
        //item.InitItem("이름" , 최대갯수);
        //item.Count = ;
        //_itemsDic.Add(item.name , item);
        //_itemslist.Add(item);
    }

    public bool UseItem(int index)
    {
        if (_itemslist[index].Count == 0)
        {
            return false;
        }

        _itemslist[index].Count -= 1;

        return true;
    }

    public bool GetItem(int index)
    {
        if (_itemslist[index].Count == _itemslist[index].MaxCount)
            return false;

        _itemslist[index].Count++;
        return true;
    }
    public bool GetItem(Item item)
    {
        Item it = _itemsDic[item.Name];

        if (it.Count == it.MaxCount)
            return false;

        it.Count = Math.Min(it.MaxCount , it.Count + item.Count);
        return true;
    }
}