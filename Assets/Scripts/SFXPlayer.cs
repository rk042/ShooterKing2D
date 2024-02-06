using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private static SFXPlayer instance;
    
    [SerializeField] AudioSource audioSourceEnemie;
    [SerializeField] AudioSource audioSourceLevelUp;
    [SerializeField] AudioSource audioSourceBg;
    [SerializeField] AudioSource audioSourcePlayer;
    [SerializeField] AudioSource audioSourceCoin;
    [SerializeField] AudioSource audioSourcePlayerHeathDown;
    [SerializeField] AudioSource audioSourceEnemieDetected;
    [SerializeField] AudioSource audioSourceCongratulation;
    [SerializeField] AudioSource audioSourceJump;
    [SerializeField] AudioSource audioSourceFailed;

    [SerializeField] AudioClip playerShoot;
    [SerializeField] AudioClip enemieSound;
    [SerializeField] AudioClip levelUp;
    [SerializeField] AudioClip coinCollect;
    [SerializeField] AudioClip playerHeathDown;
    [SerializeField] AudioClip enemieDetected;
    [SerializeField] AudioClip congratulation;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip failed;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public static void SFXSoundPlayer()
    {
        instance.audioSourcePlayer.PlayOneShot(instance.playerShoot);
    }
    public static void SFXEnemie()
    {
        instance.audioSourceEnemie.PlayOneShot(instance.enemieSound);
    }

    public static void SFXLevelUp()
    {
        instance.audioSourceLevelUp.PlayOneShot(instance.levelUp);
    }

    public static void SFXCoinCollect()
    {
        instance.audioSourceCoin.PlayOneShot(instance.coinCollect);
    }

    public static void SFXPlayerHeathDown()
    {
        instance.audioSourcePlayerHeathDown.PlayOneShot(instance.playerHeathDown);
    }

    public static void SFXEnemieDetected()
    {
        instance.audioSourceEnemieDetected.PlayOneShot(instance.enemieDetected);
    }
    public static void SFXCongratulation()
    {
        instance.audioSourceCongratulation.PlayOneShot(instance.congratulation);
    }
    public static void SFXJump()
    {
        instance.audioSourceJump.PlayOneShot(instance.jump);
    }
    public static void SFXFailed()
    {
        instance.audioSourceFailed.PlayOneShot(instance.failed);
    }

    private void OnDestroy()
    {
        instance=null;
    }
}
