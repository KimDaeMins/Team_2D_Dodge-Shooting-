using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementBuff : Inven_Base
{
    public override void UseItem()
    {

        int powerLevel = Managers.Object.GetPlayer().GetComponent<Player>()._powerLevel;
        if (powerLevel == 5)
        {
            //플레이어의 powerLevel이 5인 경우에 할 작업을 여기에 작성
            Debug.Log("플레이어의 powerLevel은 5입니다.");
            Debug.Log("10초간 강력한 공격을 발사합니다.");
            //10초간 강력한 레이저를 추가로 쏜다
            //10초간 Powerlevel을 한정적으로 더올린다 등등
        }
        else
        {
            // 플레이어의 powerLevel이 5가 아닌 경우에 할 작업을 여기에 작성
            Debug.Log("플레이어의 powerLevel은 5가 아닙니다.");
            Managers.Object.GetPlayer().GetComponent<Player>().AddPowerLevel();
        }



    }

 
}
