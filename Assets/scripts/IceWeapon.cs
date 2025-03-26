using System.Collections;
using UnityEngine;

public class IceWeapon : Weapon
{
    public override void ApplyEffect(Character target)
    {
        StartCoroutine(DoIceDamage(target, 5, 1f));
    }

    private IEnumerator DoIceDamage(Character target, int hits, float delay)
    {
        for (int i = 0; i < hits; i++)
        {
            target.GetHit(1);
            Debug.Log($"Ice attack! Enemy HP: {target.GetHealth()}");
            yield return new WaitForSeconds(delay);
        }
    }
}