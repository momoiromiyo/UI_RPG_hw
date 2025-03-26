using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected int aggression = 10;

    private void Awake()
    {
        SetCharacterName(name); // Atjauno vārdu no Inspectora
    }

    public override int Attack()
    {
        return Weapon.GetDamage() + aggression / 10;
    }
}