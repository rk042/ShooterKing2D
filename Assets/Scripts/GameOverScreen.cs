using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtMessage;
    
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void ShowScreen(string message)
    {
        canvas.enabled = true;
        txtMessage.text = message;
    }
}
