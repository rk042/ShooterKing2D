using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public GameState State { get; set; } = GameState.GamePlay;
    
    public event Action<int> CoinUpdate;
    public Action<int> PlayerHealthChange;

    public int SaveLoadCoin
    {
        get
        {
           return PlayerPrefs.GetInt("coin", 0);
        }
        set
        {
            CoinUpdate?.Invoke(value);
            PlayerPrefs.SetInt("coin", value);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
