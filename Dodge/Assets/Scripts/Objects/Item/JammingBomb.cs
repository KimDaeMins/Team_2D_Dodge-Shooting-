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



        //        // 아이템을 화면에서 제거하거나 기타 처리를 할 수 있습니다.
        //        Managers.Resource.Destroy(monsterBullets);
        //        Debug.Log("투사체를 국소적으로 파괴합니다.");

        //    }
        //}
        
    }
}
