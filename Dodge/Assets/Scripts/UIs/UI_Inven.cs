using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Base
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        foreach (Transform child in transform.GetChild(0).transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        foreach(var a in Managers.Data._itemUIsList)
            a.Clear();

        for (int i = 0 ; i < Managers.Data._itemslist.Count ; ++i)
        {
            GameObject panel = Managers.Resource.Instantiate("HorizonPanel");
            panel.transform.SetParent(transform.GetChild(0).transform);
            for (int j = 0 ; j < Managers.Data._itemslist[i].MaxCount ; ++j)
            {
                GameObject go = Managers.Resource.Instantiate("UI_Inven_Item");
                UI_Inven_Item item = Util.GetOrAddComponent<UI_Inven_Item>(go);
                item.Init();
                item.transform.SetParent(panel.transform);
                Managers.Data._itemUIsList[i].Add(item);
                item.SetSprite(Managers.Resource.LoadSprite(Managers.Data._itemslist[i].Name));
            }
            Managers.Data.ItemUpdate(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
