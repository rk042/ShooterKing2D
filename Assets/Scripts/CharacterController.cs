using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public static EventHandler<CharacterCollideToGround> Event_IsCharactCollideToGround;
}

public class CharacterCollideToGround:EventArgs
{
    public bool isHitToGround;
}

public enum Tags
{
    Ground,
}