using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : TowerShoot
{
    public Laser LaserObj;
    private GameObject CurLaser;

    private void Awake()
    {
        CurLaser = Instantiate(LaserObj.gameObject, ShootPos.position, ShootPos.rotation);
        CurLaser.transform.parent = transform.GetChild(0);
        CurLaser.SetActive(false);
    }

    public override void Shoot(Transform target)
    {
        if(!CurLaser.activeSelf)
            CurLaser.SetActive(true);
        CurLaser.GetComponent<Laser>().UpdateData(ShootPos, target, TowerData.Damage);
    }

    public override void ResetShoot()
    {
        CurLaser.SetActive(false);
    }

    private void OnDestroy()
    {
        Destroy(CurLaser);
    }
}
