using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter : Singleton<DataCenter>
{

    public bool isMuted = false;
    public override void Awake()
    {
        base.Awake();
    }

}