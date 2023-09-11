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
    }

    public bool UseItem(int index)
    {
        if (_itemslist[index].Count == 0)
        {
            Debug.Log("없습니다.");
            return false;
        }

        _itemslist[index].Count -= 1;
        switch (index)
        {
            case 0: // ClearBomb
                    // ClearBomb에 대한 작업 수행
                Debug.Log("ClearBomb을 사용했습니다.");
                break;
            case 1: // JammingBomb
                    // JammingBomb에 대한 작업 수행
                Debug.Log("JammingBomb을 사용했습니다.");
                break;
            case 2: // MissileBomb
                    // MissileBomb에 대한 작업 수행
                Debug.Log("MissileBomb을 사용했습니다.");
                break;
            case 3: // EnhancementBuff
                    // EnhancementBuff에 대한 작업 수행
                Debug.Log("EnhancementBuff를 사용했습니다.");
                break;
            default:
                Debug.Log("알 수 없는 아이템을 사용했습니다.");
                break;
        }


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

        it.Count = Math.Min(it.MaxCount , it.Count + item.Count);
        return true;
    }
}