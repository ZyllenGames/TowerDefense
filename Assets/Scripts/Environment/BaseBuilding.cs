using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : LifeEntity
{
    public event System.Action<float> OnHealthChanged;

    public override void Die()
    {
        base.Die();
        MasterManager.Instance.Lose();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnHealthChanged(CurHealth);
    }

}
