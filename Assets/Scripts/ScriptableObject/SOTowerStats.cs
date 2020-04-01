using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Object/Tower Stats")]
public class SOTowerStats : ScriptableObject
{
    public TowerStat[] TowerStats;

    public GameObject FindTowerPrefab(string name, int level)
    {
        for (int i = 0; i < TowerStats.Length; i++)
        {
            if (TowerStats[i].Name == name)
            {
                return TowerStats[i].TowerPrefab[level];
            }
        }
        return null;
    }

    public int GetTowerCost(string name, int level)
    {
        for (int i = 0; i < TowerStats.Length; i++)
        {
            if (TowerStats[i].Name == name)
            {
                return TowerStats[i].Cost[level];
            }
        }
        return -1;
    }

    public void GetTowerInfo(string name, int level, out int upgradecost, out int sellmoney, ref GameObject upgradeprefab)
    {
        for (int i = 0; i < TowerStats.Length; i++)
        {
            if (TowerStats[i].Name == name)
            {
                if(level == 2)
                {
                    upgradecost = 0;
                    sellmoney = TowerStats[i].Sell[level];
                    return;
                }
                else
                {
                    int nextLevel = level + 1;
                    upgradecost = TowerStats[i].Cost[nextLevel];
                    sellmoney = TowerStats[i].Sell[level];
                    upgradeprefab = TowerStats[i].TowerPrefab[nextLevel];
                    return;
                }
            }
        }
        upgradecost = 0;
        sellmoney = 0;
        upgradeprefab = null;
    }
}

[System.Serializable]
public class TowerStat
{
    public string Name;
    public GameObject[] TowerPrefab;
    public int[] Cost;
    public int[] Sell;
}
