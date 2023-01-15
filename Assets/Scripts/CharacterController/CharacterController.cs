using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class CharacterController : MonoBehaviour
{
    public static EventHandler<CharacterCollideToGround> Event_IsCharactCollideToGround;

    public class CharacterCollideToGround:EventArgs
    {
        public bool isHitToGround;
    }
    public virtual void UpdateBase(){}
    private void Update()
    {
        UpdateBase();
    }
}

public enum Tags
{
    Ground,
}