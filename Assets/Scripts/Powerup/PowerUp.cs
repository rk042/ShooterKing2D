using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected IPowerUp powerUp;

    public virtual void ApplyPowerUp(IPowerUp _powerUp) 
    { 
        powerUp = _powerUp; 
        powerUp.Add(this);
    }
    protected void RemovePowerUp() 
    {
        powerUp.Remove(this);
    }
}
