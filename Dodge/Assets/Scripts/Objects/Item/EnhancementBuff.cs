using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementBuff : Inven_Base
{
    public override void UseItem()
    {
        Debug.Log("��ȭ��30��");

        Managers.Object.GetPlayer().GetComponent<Player>().AddPowerLevel();
        
    }

 
}
