using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DataManager
{
    public Sprite UserSprite { get; set; }
    public RuntimeAnimatorController AnimatorController { get; set; }



    public void Init()
    {
        //UserSprite = Managers.Resource.LoadSprite("elf");
    }
}