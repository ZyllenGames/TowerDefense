using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public SOTowerData TowerData;

    Transform m_Target = null;
    float m_RotateSpeed = 0.9f;
    private float m_CurAngleY = 0f;
    float m_SearchInterval = 0.5f;

    public Tile Tile;

    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, m_SearchInterval);
    }

    void Update()
    {
        if(m_Target != null)
        {
            if(RotateTowardsTarget())
                GetComponent<TowerShoot>().Shoot(m_Target);
        }
        else
        {
            GetComponent<TowerShoot>().ResetShoot();
        }
    }

    bool RotateTowardsTarget()
    {
        Vector3 dir = m_Target.position - transform.position;
        float angle = dir.CalculateDirAngleY();
        m_CurAngleY = Mathf.LerpAngle(m_CurAngleY, angle, m_RotateSpeed);
        transform.GetChild(0).rotation = Quaternion.Euler(0f, m_CurAngleY, 0f);
        
        if (Mathf.Abs(Mathf.DeltaAngle(m_CurAngleY, angle)) < 5) // Check if Head is right towards the target
            return true;
        else
            return false;
    }

    void SearchTarget()
    {
        Enemy[] allEnemy = FindObjectsOfType<Enemy>();
        float minDist = Mathf.Infinity;
        m_Target = null;

        foreach (Enemy enemy in allEnemy)
        {
            float sqrDist = Vector3.SqrMagnitude(enemy.gameObject.transform.position - transform.position);
            if(sqrDist < Mathf.Pow(TowerData.ShootRange, 2))
            {
                if(sqrDist < minDist)
                {
                    m_Target = enemy.gameObject.transform;
                    minDist = sqrDist;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerData.ShootRange);
    }
}
