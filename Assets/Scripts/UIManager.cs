using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    [SerializeField] TextMeshProUGUI txtScoreCount;
    [SerializeField] Cinemachine.CinemachineImpulseSource cinemachineImpulse;
    [SerializeField] AudioSource audioSourceVFX;
    [SerializeField] AudioSource audioSourceBg;
    [SerializeField] AudioSource audioSourcePlayer;
    [SerializeField] AudioClip playerShoot;
    [SerializeField] AudioClip enemieSound;
    [SerializeField] AudioClip levelUp;

    public static int scoreCount{get;private set;}

    private void Awake()
    {
        instance=this;
    }

    public static void UpdateScore()
    {
        scoreCount++;
        instance.txtScoreCount.text=$"Killed : {scoreCount}";
    }

    public static void ShakeScreen()
    {
        instance.cinemachineImpulse.GenerateImpulse();
    }

    public static void VFXSoundPlayer()
    {
        instance.audioSourcePlayer.PlayOneShot(instance.playerShoot);
    }
    public static void VFXEnemie()
    {
        instance.audioSourceVFX.PlayOneShot(instance.enemieSound);
    }

    public static void VFXLevelUp()
    {
        instance.audioSourceVFX.PlayOneShot(instance.levelUp);
    }
}
