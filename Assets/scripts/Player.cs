using UnityEngine;

public class Player : Character
{
    private void Awake()
    {
        SetCharacterName(name); // Atjauno vārdu no Inspectora
    }

    public override int Attack()
    {
        return Weapon.GetDamage();
    }
}