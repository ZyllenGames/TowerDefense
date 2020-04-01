using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : LifeEntity
{
    public SOValue Rewards;
    public SOValue HealthIncrease;
    [SerializeField]
    private float m_Speed = 10f;
    [SerializeField]
    float m_Damage = 2;

    bool IsSlow;

    public Image HealthBar;

    public static event System.Action EnemyKilled;

    void Start()
    {
        StartCoroutine(MoveAlongWayPoints());
    }

    IEnumerator MoveAlongWayPoints()
    {
        for (int i = 0; i < WayPoints.WayPointsTrans.Length; i++)
        {
            while(Vector3.SqrMagnitude(transform.position - WayPoints.WayPointsTrans[i].position) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, WayPoints.WayPointsTrans[i].position, m_Speed * Time.deltaTime);
                yield return null;
            }
        }
        BaseBuilding basebuilding = FindObjectOfType<BaseBuilding>();
        if(basebuilding != null)
            basebuilding.GetComponent<IDamagable>().TakeDamage(m_Damage);
        EnemyKilled();
        Destroy(gameObject);
    }

    public void SlowDown(float slowratio, float duration)
    {
        float originSpeed = m_Speed;
        if (!IsSlow)
            StartCoroutine(Slow(originSpeed, slowratio, duration));
    }

    IEnumerator Slow(float originspeed, float slowratio, float duration)
    {
        m_Speed = m_Speed * slowratio;
        IsSlow = true;
        yield return new WaitForSeconds(duration);
        m_Speed = originspeed;
        IsSlow = false;
    }

    public void RaiseStats(float healthRaise, float damageRaise)
    {
        StartHealth += healthRaise * HealthIncrease.Value;
        InitHealth();
        m_Damage += damageRaise;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        float healthRatio = CurHealth / StartHealth;
        HealthBar.rectTransform.localScale = new Vector3(healthRatio, 1, 1);
    }

    public override void Die()
    {
        base.Die();
        EnemyKilled();
        MoneyManager.Instance.EarnMoney((int)(Rewards.Value));
    }
}
