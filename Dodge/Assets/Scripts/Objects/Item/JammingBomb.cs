using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingBomb : Inven_Base
{
    public override void UseItem()
    {

        Managers.Resource.Instantiate("JammingPrefab");


        //LinkedList<GameObject> monsterBullets = Managers.Object.GetAllObject(Define.Object.MonsterBullet);
        //void OnTriggerEnter2D(Collider2D other)
        //{
        //    if (other.CompareTag("monsterBullet"))
        //    {
        //        Player player = other.GetComponent<Player>();



        //        // �������� ȭ�鿡�� �����ϰų� ��Ÿ ó���� �� �� �ֽ��ϴ�.
        //        Managers.Resource.Destroy(monsterBullets);
        //        Debug.Log("����ü�� ���������� �ı��մϴ�.");

        //    }
        //}
        
    }
}
