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

    public Dictionary<string, Inven_Base> _itemsDic = new Dictionary<string , Inven_Base>();
    public List<Inven_Base> _itemslist = new List<Inven_Base>();

    public void Init()
    {
        //여기서 딕셔너리랑 리스트에 아이템을 전부 넣어준다
        //Item item = new Item();
        //item.InitItem("이름" , 최대갯수);
        //GetItem()
        //_itemsDic.Add(item.name , item);
        //_itemslist.Add(item);


        Inven_Base clearBomb = new ClearBomb();
        clearBomb.InitItem("ClearBomb", 1);
        _itemsDic.Add(clearBomb.Name, clearBomb);
        _itemslist.Add(clearBomb);

        // JammingBomb 아이템 초기화
        Inven_Base jammingBomb = new JammingBomb();
        jammingBomb.InitItem("JammingBomb", 3);
        _itemsDic.Add(jammingBomb.Name, jammingBomb);
        _itemslist.Add(jammingBomb);

        // MissileBomb 아이템 초기화
        Inven_Base missileBomb = new MissileBomb();
        missileBomb.InitItem("MissileBomb", 3);
        _itemsDic.Add(missileBomb.Name, missileBomb);
        _itemslist.Add(missileBomb);

        // EnhancementBuff 아이템 초기화
        Inven_Base enhancementBuff = new EnhancementBuff();
        enhancementBuff.InitItem("EnhancementBuff", 1);
        _itemsDic.Add(enhancementBuff.Name, enhancementBuff);
        _itemslist.Add(enhancementBuff);

        Inven_Base addPowerLevel = new AddPowerLevel();
        addPowerLevel.InitItem("AddPowerLevel", 5);
        _itemsDic.Add(addPowerLevel.Name, addPowerLevel);
        _itemslist.Add(addPowerLevel);
    }

    public bool UseItem(int index)
    {
        if (_itemslist[index].Count == 0)
        {
            Debug.Log("없습니다.");
            return false;
        }

        _itemslist[index].Count -= 1;

        _itemslist[index].UseItem();


                return true;
    }

    public bool GetItem(int index, int count = 1)
    {
        if (_itemslist[index].Count == _itemslist[index].MaxCount)
            return false;

        _itemslist[index].Count = Math.Min(_itemslist[index].MaxCount , _itemslist[index].Count + count);
        return true;
    }
    public bool GetItem(Item item)
    {
        Inven_Base it = _itemsDic[item.Name];

        if (it.Count == it.MaxCount)
            return false;

        if( item.Name == "AddPowerLevel")
        {
            Managers.Object.GetPlayer().GetComponent<Player>().AddPowerLevel();
        }

            it.Count = Math.Min(it.MaxCount , it.Count + item.Count);
        return true;
    }
}