using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementBuff : Inven_Base
{
    public override void UseItem()
    {
        Managers.Object.GetPlayer().GetComponent<Player>().StartCoroutine("activatebuff");
    }
}
