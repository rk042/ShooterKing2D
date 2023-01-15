using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static Vector3 points {get; private set;}

    private void Update()
    {
        points = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
