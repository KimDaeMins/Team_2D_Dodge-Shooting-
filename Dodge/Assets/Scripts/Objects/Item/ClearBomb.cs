using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBomb : Inven_Base
{
    
    // Start is called before the first frame update
    public override void UseItem()
    {

        //Debug.Log("ClearBomb�� ����߽��ϴ�.");
        //GameObject[] monsterBullets = GameObject.FindGameObjectsWithTag("MonsterBullet");

        //foreach (GameObject bullet in monsterBullets)
        //{
        //    Destroy(bullet);
        //}

        LinkedList<GameObject> monsterBullets = Managers.Object.GetAllObject(Define.Object.MonsterBullet);
        foreach (GameObject bullet in monsterBullets)
        {
            Managers.Resource.Destroy(bullet);
        }
    }
}