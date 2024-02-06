using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField] TextMeshProUGUI txtScoreCount;
    [SerializeField] TextMeshProUGUI txtPlayerHeath;
    [SerializeField] TextMeshProUGUI txtPlayerCoin;
    [SerializeField] Cinemachine.CinemachineImpulseSource cinemachineImpulse;
    
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] SOLevel SOLevel;

    private int scoreCount { get; set;}

    private LevelCompleteSystem levelCompleteSystem;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        levelCompleteSystem = FindObjectOfType<LevelCompleteSystem>();

        UpdateScoreUI(100);
        UpdateCoinUI(GameManager.Instance.SaveLoadCoin);
    }

    private void OnEnable()
    {
        GameManager.Instance.CoinUpdate += Instance_CoinUpdate;
        GameManager.Instance.PlayerHealthChange += PlayerHeathChange;
    }
    private void OnDisable()
    {
        GameManager.Instance.CoinUpdate -= Instance_CoinUpdate;
        GameManager.Instance.PlayerHealthChange -= PlayerHeathChange;
    }

    private void Instance_CoinUpdate(int obj)
    {
        UpdateCoinUI(obj);
    }

    private void UpdateCoinUI(int obj)
    {
        txtPlayerCoin.text = $"Coin {obj}";
    }

    private void PlayerHeathChange(int obj)
    {
        UpdateScoreUI(obj);
    }

    private void UpdateScoreUI(int obj)
    {
        txtPlayerHeath.text = $"Health : {obj}";
    }

    public static void UpdateScore()
    {
        instance.scoreCount++;
        instance.txtScoreCount.text=$"Score : {instance.scoreCount}";

        instance.levelCompleteSystem.UpdateLevelSlider(instance.scoreCount);
    }

    public static void ShakeScreen()
    {
        instance.cinemachineImpulse.GenerateImpulse();
    }

    public static void GameOver(string message)
    {
        GameManager.Instance.State = GameState.GameOver;
        instance.gameOverScreen.ShowScreen(message);
    }
}
