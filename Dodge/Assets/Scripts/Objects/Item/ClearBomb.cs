using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBomb : Inven_Base
{
    
    // Start is called before the first frame update
    public override void UseItem()
    {

        Debug.Log("ClearBomb을 사용했습니다.");
        
        Managers.Resource.Instantiate("ClearBomb");

        LinkedList<GameObject> monsterBullets = Managers.Object.GetAllObject(Define.Object.MonsterBullet);
        int bulletCount = monsterBullets.Count;
        for(int i = 0 ; i < bulletCount ; ++i)
        {
            if(monsterBullets.Count >= 1)
                Managers.Resource.Destroy(monsterBullets.First.Value);
        }
    }
}
