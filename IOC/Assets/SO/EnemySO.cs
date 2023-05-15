using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class EnemySO : ScriptableObject
{
    public float MaxHP;
    public float CurrentHP;
    public float Attack;
    public float Defense;
    public float Speed;
    public float Magic;
    public float MagicDefense;
    public float Luck;
    public float Accuracy;
    public float Evasion;
    public float CritChance;
    public float CritDamage;
    public float Exp;
    public float Gold;
    public float DropRate;
    public float DropAmount;
    public float DropChance;
    public float DropType;
    public float DropQuality;
    public float DropRarity;
    public float DropLevel;
    public float DropValue;

    public entity GetEntity()
    {
        return new entity(this);
    }
}


public class entity
{
    public float MaxHP;

    public entity(EnemySO data)
    {
        MaxHP = data.MaxHP;
    }
}