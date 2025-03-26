using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string charName;
    [SerializeField] protected int health;
    public Weapon Weapon;

    public string GetCharacterName() => charName;
    public void SetCharacterName(string name) => charName = name; // Setter nosaukumam
    public int GetHealth() => health;
    public void SetHealth(int value) => health = Mathf.Max(0, value); // Setter ar minimumu 0
    public bool IsDead() => health <= 0;

    public virtual void GetHit(int damage)
    {
        SetHealth(health - damage);
    }
    
    public void GetHit(int damage, bool isCritical) // Overload metode
    {
        int finalDamage = isCritical ? damage * 2 : damage;
        SetHealth(health - finalDamage);
    }
    
    public void RestoreHealth(int amount)
    {
        health += amount;
    }
    
    public abstract int Attack();
}