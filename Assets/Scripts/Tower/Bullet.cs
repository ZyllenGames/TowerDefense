using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject m_HitEffect;
    public GameObject m_SmokeEffect;

    [SerializeField]
    float m_Damage = 1;
    [SerializeField]
    private float m_Speed = 30f;
    int m_DamageRange = 0;
    [SerializeField]
    float m_EffectLifeLength = 2f;


    private Transform m_Target;
    private Vector3 m_TargetPos;
    
    public void SetTarget(Transform target)
    {
        m_Target = target;
        m_TargetPos = m_Target.position;
    }

    public void SetDamageAndRange(float damage, int range)
    {
        m_Damage = damage;
        m_DamageRange = range;
    }

    void Update()
    {
        if(m_Target != null)
        {
            m_TargetPos = m_Target.position;
        }

        while ((transform.position - m_TargetPos).sqrMagnitude > m_Speed * Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_TargetPos, m_Speed * Time.deltaTime);
            return;
        }
        HitTarget();
    }

    void HitTarget()
    {
        if(m_DamageRange > 0f)
        {
            Explode();
        }
        else
        {
            if (m_Target != null)
                m_Target.GetComponent<IDamagable>().TakeDamage(m_Damage);
        }
        GameObject neweffect = Instantiate(m_HitEffect, transform.position, Quaternion.identity);
        Destroy(neweffect, m_EffectLifeLength);


        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_DamageRange);
        foreach (Collider col in colliders)
        {
            if(col.tag == "Enemy")
            {
                col.GetComponent<IDamagable>().TakeDamage(m_Damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_DamageRange);
    }

}
