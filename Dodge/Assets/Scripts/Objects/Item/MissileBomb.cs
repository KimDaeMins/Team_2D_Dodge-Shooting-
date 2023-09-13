using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MissileBomb : Inven_Base
{
    

    // Player스크립트 안에 있는 불렛트랜스를 그 이후에 받아오시면



    public override void UseItem()
    {
        //Player player = Managers.Object.GetPlayer().GetComponent<Player>();

        //    _bulletTrans = player._bulletTrans;

        //GameObject missile = Managers.Resource.Instantiate("Missile", _bulletTrans.position, _bulletTrans.rotation);

        Managers.Object.GetPlayer().GetComponent<Player>().MissileFire();
    }

   

}
