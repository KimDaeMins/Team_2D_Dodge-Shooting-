using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MissileBomb : Inven_Base
{
    

    public override void UseItem()
    {
        Managers.Resource.Instantiate("missilePrefab"); 



        Debug.Log("������ �̻����� �߻��մϴ�.");
    }

   

}
