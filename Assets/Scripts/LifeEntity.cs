using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntity : MonoBehaviour, IDamagable
{
    public float StartHealth;
    [SerializeField]
    protected float CurHealth;

    public GameObject DieEffect;

    bool IsDead = false;


    public virtual void Die()
    {
        IsDead = true;
        if (DieEffect != null)
        {
            GameObject eff = Instantiate(DieEffect, transform.position, Quaternion.identity);
            Color entitycolor = GetComponent<Renderer>().material.color;
            eff.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = entitycolor;
            Destroy(eff, 2);
        }
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        if (CurHealth > damage)
            CurHealth -= damage;
        else
        {
            CurHealth = 0;
            if(!IsDead)
                Die();
        }
    }

    private void Awake()
    {
        InitHealth();
    }

    public void InitHealth()
    {
        CurHealth = StartHealth;
    }
}
