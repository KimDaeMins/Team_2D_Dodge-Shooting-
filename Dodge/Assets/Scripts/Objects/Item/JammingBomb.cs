using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {
            // JammingPrefab�� ����
            Managers.Resource.Instantiate("JammingBomb");

    }
}
