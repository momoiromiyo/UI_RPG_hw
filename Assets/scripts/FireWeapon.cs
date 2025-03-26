using System.Collections;
using UnityEngine;

public class FireWeapon : Weapon
{
    public int fireDamage = 5;
    public override void ApplyEffect(Character target)
    {
        StartCoroutine(DoFireDamage(target, 3, 0.5f));
    }

    private IEnumerator DoFireDamage(Character target, int hits, float delay)
    {
        for (int i = 0; i < hits; i++)
        {
            target.GetHit(fireDamage);
            Debug.Log($"Fire attack! Enemy HP: {target.GetHealth()}");
            yield return new WaitForSeconds(delay);
        }
    }
}