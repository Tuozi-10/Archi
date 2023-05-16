using UnityEngine;

[CreateAssetMenu(menuName = "Perso", fileName = "new Perso")]
public class PersoSO : ScriptableObject
{
    public int health;
    public int damage;
    public int speed;
}

public class Perso
{
    public int health;
    public int damage;
    public int speed;

    public Perso(PersoSO so)
    {
        health = so.health;
        damage = so.damage;
        speed = so.speed;
    }
}
