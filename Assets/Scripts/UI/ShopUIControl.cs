using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIControl : MonoBehaviour
{
    public void OnCanonTowerButtonSelected()
    {
        BuildManager.Instance.SetCurTower("Canon");
    }

    public void OnMissileTowerButtonSelected()
    {
        BuildManager.Instance.SetCurTower("Missile");
    }

    public void OnLaserTowerButtonSelected()
    {
        BuildManager.Instance.SetCurTower("Laser");
    }
}
