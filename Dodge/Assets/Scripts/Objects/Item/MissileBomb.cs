using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MissileBomb : Inven_Base
{
    

    // Player��ũ��Ʈ �ȿ� �ִ� �ҷ�Ʈ������ �� ���Ŀ� �޾ƿ��ø�



    public override void UseItem()
    {
        //Player player = Managers.Object.GetPlayer().GetComponent<Player>();

        //    _bulletTrans = player._bulletTrans;

        //GameObject missile = Managers.Resource.Instantiate("Missile", _bulletTrans.position, _bulletTrans.rotation);

        Managers.Object.GetPlayer().GetComponent<Player>().MissileFire();
    }

   

}
