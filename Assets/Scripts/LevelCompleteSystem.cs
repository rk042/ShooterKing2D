using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteSystem : MonoBehaviour
{
    [SerializeField] Slider levelSlider;
    [SerializeField] SOLevel SOlevel;

    private void Awake()
    {
        levelSlider.maxValue = SOlevel.EnemieSpawnCount;
    }
   
    public void UpdateLevelSlider(float level)
    {
        levelSlider.value = level;
    }

    public void SliderValueUpdate(float value)
    {
        if (value >= SOlevel.EnemieSpawnCount)
        {
            Debug.Log("Level Complete");
            SFXPlayer.SFXCongratulation();
            UIManager.GameOver("Congratulations soldier ready for next mission ?");
        }
    }


    private void OnDestroy()
    {
        levelSlider.value = 0;
    }
}
