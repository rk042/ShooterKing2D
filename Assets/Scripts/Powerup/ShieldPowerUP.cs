using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUP : PowerUp
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    int shieldPower = 100;
    
    public override void ApplyPowerUp(IPowerUp _powerUp)
    {
        base.ApplyPowerUp(_powerUp);
        spriteRenderer = _powerUp.GetRenderer();
        spriteRenderer.sprite = sprites[1];
    }

    public void HitShield(int demage)
    {
        shieldPower-=demage;

        if (shieldPower<=0)
        {
            spriteRenderer.sprite = null;
            RemovePowerUp();
            return;
        }
        if (shieldPower>=10 && shieldPower<=20)
        {
            spriteRenderer.sprite = sprites[8];
        }
        if (shieldPower>=20 && shieldPower<=30)
        {
            spriteRenderer.sprite = sprites[7];
        }
        if (shieldPower>=30 && shieldPower<=40)
        {
            spriteRenderer.sprite = sprites[6];
        }
        if (shieldPower>=40 && shieldPower<=50)
        {
            spriteRenderer.sprite = sprites[5];
        }
        if (shieldPower>=50 && shieldPower<=60)
        {
            spriteRenderer.sprite = sprites[4];
        }
        if (shieldPower>=60 && shieldPower<=70)
        {
            spriteRenderer.sprite = sprites[3];
        }
        if (shieldPower>=80 && shieldPower<=90)
        {
            spriteRenderer.sprite = sprites[2];
        }
        if (shieldPower>=90)
        {
            spriteRenderer.sprite = sprites[1];
        }
    }
}
