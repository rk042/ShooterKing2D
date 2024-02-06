using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] GameObject coin;

    IEnemieData enemieData;

    private void Awake()
    {
        enemieData = GetComponent<IEnemieData>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.Ground.ToString()))
        {
            enemieData.IsStartGame = true;
        }
        else if(other.collider.CompareTag(Tags.Bullet.ToString()))
        {
            UIManager.UpdateScore();
            SFXPlayer.SFXEnemie();
            GenerateCoin();
            DestroyEffect();
        }
        else if (other.collider.CompareTag(Tags.Player.ToString()))
        {
            if(other.collider.TryGetComponent(out ICharacterHeath characterHeath))
            {
                characterHeath.ReduceHealthAction(enemieData.DemageAmountToPlayer);
                DestroyEffect();
            }
        }
    }

    private void GenerateCoin()
    {
        var cointemp = Instantiate(coin, transform.position, Quaternion.identity);
        if (cointemp.TryGetComponent(out Rigidbody2D rd))
        {
            rd.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
        }
    }

    private void DestroyEffect()
    {
        UIManager.ShakeScreen();
        Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
