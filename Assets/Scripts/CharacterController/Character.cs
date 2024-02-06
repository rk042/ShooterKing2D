using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IPowerUp
{
    public List<PowerUp> PowerUps { get; set; } = new List<PowerUp>();

    public ICharacterJump CharacterJump { get; private set;}
    public ICharacterHeath CharacterHeath {get; private set;}

    [field: SerializeField] public SpriteRenderer ShieldSpriteRenderer { get; private set; }

    private void Awake()
    {
        CharacterJump = GetComponent<ICharacterJump>();
        CharacterHeath = GetComponent<ICharacterHeath>();
    }

    public SpriteRenderer GetRenderer()
    {
        return ShieldSpriteRenderer;
    }

    public void Add(PowerUp add)
    {
        Debug.Log("powerup added");
        PowerUps.Add(add);
    }

    public void Remove(PowerUp remove)
    {
        if (PowerUps.Contains(remove))
        {
            PowerUps.Remove(remove);
        }
    }

    public bool TryGetPowerUp<T>(out T shield) where T : PowerUp
    {

        foreach (var item in PowerUps)
        {
            if (item is T a)
            {
                shield = a;
                return true;
            }
        }

        shield = null;
        return false;
    }
}
