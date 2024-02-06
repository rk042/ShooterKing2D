using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level",menuName = "Platform/Create New Level")]
public class SOLevel : ScriptableObject
{
    [field:SerializeField] public int EnemieSpawnCount { get; private set; }
    [field:SerializeField] public int BulletLimit { get; private set; }
    [field:SerializeField] public int PlayerHealth { get; private set; }
    public void UpdateBulletLimit(int increaseBullet)
    {
        BulletLimit = increaseBullet;
    }
}
