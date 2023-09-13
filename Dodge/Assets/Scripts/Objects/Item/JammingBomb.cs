using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {
        // JammingPrefab을 생성
        //GameObject jammingBomb = Managers.Resource.Instantiate("JammingBomb");

        //Debug.Log("재밍 폭탄이 발사됩니다.");
        Managers.Object.GetPlayer().GetComponent<Player>().JammingFire();
    }
}
