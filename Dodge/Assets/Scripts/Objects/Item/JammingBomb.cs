using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {
        // JammingPrefab�� ����
        //GameObject jammingBomb = Managers.Resource.Instantiate("JammingBomb");

        //Debug.Log("��� ��ź�� �߻�˴ϴ�.");
        Managers.Object.GetPlayer().GetComponent<Player>().JammingFire();
    }
}
