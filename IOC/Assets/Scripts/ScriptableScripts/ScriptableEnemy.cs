using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    public EnemyData data;

    public Enemy CreateEnemy()
    {
        return new Enemy(data);
    }
}

[Serializable]
public struct EnemyData
{
    public int maxHp;
    public int attackDamage;
    public int moveSpeed;
}

public class Enemy
{
    public EnemyData data;

    public Enemy(EnemyData data)
    {
        this.data = data;
    }
}
