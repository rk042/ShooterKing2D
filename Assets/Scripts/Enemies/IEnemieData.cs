using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemieData
{
    public int DemageAmountToPlayer { get; }

    public bool IsStartGame { get; set; }

}