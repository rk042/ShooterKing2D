using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderController : MonoBehaviour
{
    Character character;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.Ground.ToString()))
        {
            character.CharacterJump.HitGround();
        }
        if (other.collider.CompareTag(Tags.Obsticle.ToString()))
        {
            UIManager.ShakeScreen();
            character.CharacterHeath.ReduceHealthAction(10);
        }
        if (other.collider.CompareTag(Tags.BottomCollider.ToString()))
        {
            character.CharacterHeath.ReduceHealthAction(110);
        }
        if (other.collider.CompareTag(Tags.Coin.ToString()))
        {
            GameManager.Instance.SaveLoadCoin++;
            SFXPlayer.SFXCoinCollect();
            Destroy(other.gameObject);
        }
        if (other.collider.CompareTag(Tags.ShieldPowerup.ToString()))
        {
            if (other.transform.TryGetComponent(out PowerUp powerUp))
            {
                powerUp.ApplyPowerUp(character);
            }

            Destroy(other.gameObject);
        }
    }
}
