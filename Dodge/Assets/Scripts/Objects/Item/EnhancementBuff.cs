using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementBuff : Inven_Base
{
    //private bool isBuffActive = false; // 버프 활성화 여부
    //private float buffDuration = 15f; // 버프 지속 시간 (초)


    public override void UseItem()
    
    {
    //    if (!isBuffActive)
    //    {
    //        StartCoroutine(ActivateBuff());
    //    }
    //}

    //private IEnumerator ActivateBuff()
    //{
    //    isBuffActive = true;
    //    Debug.Log("15초간 강력한 공격을 발사합니다.");

    //    // 버프를 지정된 시간 동안 유지
    //    yield return new WaitForSeconds(buffDuration);

    //    // 버프 종료 후 처리
    //    isBuffActive = false;
    //    Debug.Log("강력한 공격 버프가 종료되었습니다.");
    }

}
