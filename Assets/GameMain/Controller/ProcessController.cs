using UnityEngine;
using GameKit;
using System;
using System.Collections;
using System.Collections.Generic;

public class ProcessController : MonoSingletonBase<ProcessController>
{
   public enum Process
    {
        isGaming,isMenu,isEnd
    }
    public Process currentProcess;
    protected override void OnAwake()
    {
        currentProcess= Process.isMenu;
    }

    
  

}
