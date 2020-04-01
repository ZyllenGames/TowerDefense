using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject StartEff;
    public GameObject EndEff;

    Transform m_StartTrans;
    Transform m_TargetTrans;
    float m_Damage;

    [SerializeField]
    float m_SlowRatio = 0.5f;
    [SerializeField]
    float m_SlowDuration = 2f;

    // Update is called once per frame
    void Update()
    {
        SetLaserWithEffect();
        DamageTarget();
    }

    private void DamageTarget()
    {
        if (m_TargetTrans != null)
        {
            m_TargetTrans.GetComponent<IDamagable>().TakeDamage(m_Damage * Time.deltaTime);
            m_TargetTrans.GetComponent<Enemy>().SlowDown(m_SlowRatio, m_SlowDuration);
        }
    }

    private void SetLaserWithEffect()
    {
        if(m_TargetTrans != null && m_StartTrans != null)
        {
            Vector3 direction = m_TargetTrans.position - m_StartTrans.position;
            float dist = Vector3.Magnitude(direction);
            transform.localScale = new Vector3(0.3f, 0.3f, dist * 0.5f);
            transform.rotation = Quaternion.LookRotation(direction);

            StartEff.transform.position = m_StartTrans.position;
            EndEff.transform.position = m_TargetTrans.position - direction.normalized * 1f;
        }
    }

    public void UpdateData(Transform start, Transform target, float damage)
    {
        m_StartTrans = start;
        m_TargetTrans = target;
        m_Damage = damage;
    }
}
