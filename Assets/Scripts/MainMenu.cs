using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Button method
    /// </summary>
    /// <param name="levelIndex"></param>
    public void Btn_Level(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
