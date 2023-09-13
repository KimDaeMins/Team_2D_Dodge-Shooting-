using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {

        Managers.Resource.Instantiate("JammingPrefab");

        Debug.Log("투사체를 국소적으로 파괴합니다.");

    }
}
