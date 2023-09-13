using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {
            // JammingPrefabÀ» »ý¼º
            Managers.Resource.Instantiate("JammingBomb");

    }
}
