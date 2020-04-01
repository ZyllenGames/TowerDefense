using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private string StrCurTowerToBuild = "";
    public GameObject BuildingEffect;

    public SOTowerStats towerStats;

    public void SetCurTower(string name)
    {
        StrCurTowerToBuild = name;
    }

    public string GetCurTower()
    {
        return StrCurTowerToBuild;
    }

    public void BuildTower(Vector3 pos, Tile tile)
    {
        GameObject newTower = towerStats.FindTowerPrefab(StrCurTowerToBuild, 0);
        if (newTower != null)
        {
            GameObject tower = Instantiate(newTower, pos, Quaternion.identity);
            tower.GetComponent<Tower>().Tile = tile;
            GameObject eff = Instantiate(BuildingEffect, pos, Quaternion.identity);
            Destroy(eff, 2);
        }
    }

    public void UpdateTower(GameObject curtower, GameObject upgradeprefab)
    {
        GameObject newTower = Instantiate(upgradeprefab, curtower.transform.position, Quaternion.identity);
        newTower.GetComponent<Tower>().Tile = curtower.GetComponent<Tower>().Tile;
        Destroy(curtower);
        GameObject eff = Instantiate(BuildingEffect, curtower.transform.position, Quaternion.identity);
        Destroy(eff, 2);
    }

    public void SellTower(GameObject curtower)
    {
        GameObject eff = Instantiate(BuildingEffect, curtower.transform.position, Quaternion.identity);
        Destroy(eff, 2);
        curtower.GetComponent<Tower>().Tile.m_HasTower = false;
        Destroy(curtower);
    }
}
