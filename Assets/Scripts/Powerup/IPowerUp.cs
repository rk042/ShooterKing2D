using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{
    public void Remove(PowerUp powerUp);

    public void Add(PowerUp powerUp);   

    public SpriteRenderer GetRenderer();
}