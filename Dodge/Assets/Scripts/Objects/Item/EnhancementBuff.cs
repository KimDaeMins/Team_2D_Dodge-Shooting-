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
            //�÷��̾��� powerLevel�� 5�� ��쿡 �� �۾��� ���⿡ �ۼ�
            Debug.Log("�÷��̾��� powerLevel�� 5�Դϴ�.");
            Debug.Log("10�ʰ� ������ ������ �߻��մϴ�.");
            //10�ʰ� ������ �������� �߰��� ���
            //10�ʰ� Powerlevel�� ���������� ���ø��� ���
        }
        else
        {
            // �÷��̾��� powerLevel�� 5�� �ƴ� ��쿡 �� �۾��� ���⿡ �ۼ�
            Debug.Log("�÷��̾��� powerLevel�� 5�� �ƴմϴ�.");
            Managers.Object.GetPlayer().GetComponent<Player>().AddPowerLevel();
        }



    }

 
}
