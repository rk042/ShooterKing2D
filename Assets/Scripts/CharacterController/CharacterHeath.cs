using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CharacterHeath : MonoBehaviour, ICharacterHeath
{
    [SerializeField] SOLevel soLevel;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Volume postVolume;

    private int PlayerHealth;
    private Character character;

    private void Awake()
    {
        if (!soLevel)
        {
            throw new Exception("SO Level is null");
        }

        PlayerHealth = soLevel.PlayerHealth;
        character = GetComponent<Character>();
    }

    void ICharacterHeath.ReduceHealthAction(int demage)
    {
        if (GameManager.Instance.State != GameState.GameOver)
        {
            //if i have shield powerup
            if (character.TryGetPowerUp(out ShieldPowerUP shield))
            {
                shield.HitShield(demage);
                return;
            }

            PlayerHealth -= demage;

            SFXPlayer.SFXPlayerHeathDown();

            Instantiate(ps,transform.position + new Vector3(0,5,0),Quaternion.identity);

            GameManager.Instance.PlayerHealthChange?.Invoke(PlayerHealth);
            
            StartCoroutine(Cor_PostVolume());
           

            if (PlayerHealth <= 0)
            {
                Debug.Log($"Game Over Heath Down ");
       
                UIManager.GameOver("Health Down Soldier");
                SFXPlayer.SFXFailed();
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Cor_PostVolume()
    {
        float temp = 0;

        if(postVolume.profile.TryGet(out Vignette vignette))
        {
            float tempIntensity = vignette.intensity.value;
            
            while (true)
            {
                yield return null;
                
                temp += Time.deltaTime;
                vignette.color.value = Color.red;
                vignette.intensity.value = 0.45f;

                if (temp>=1)
                {
                    vignette.color.value = Color.black;
                    vignette.intensity.value = tempIntensity;
                    yield break;
                }
            }
        }
    }
}
