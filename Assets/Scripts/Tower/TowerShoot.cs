using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform ShootPos;
    public SOTowerData TowerData;

    protected float m_CurShootTime;

    private void Awake()
    {
        ResetShoot();
    }

    public virtual void Shoot(Transform target)
    {
        if (m_CurShootTime >= TowerData.ShootInterval)
        {
            m_CurShootTime = 0f;

            GameObject newbullet = Instantiate(BulletPrefab, ShootPos.position, ShootPos.rotation);
            newbullet.GetComponent<Bullet>().SetTarget(target);
            newbullet.GetComponent<Bullet>().SetDamageAndRange(TowerData.Damage, TowerData.DamageRange);
        }
        else
            m_CurShootTime += Time.deltaTime;
    }

    public virtual void ResetShoot()
    {
        m_CurShootTime = TowerData.ShootInterval;
    }

}
