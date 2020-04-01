using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            StartMoney = GameStats.StartMoney;
            m_CurMoney = StartMoney;
        }
    }

    int StartMoney;
    [SerializeField]
    private int m_CurMoney;

    public SOTowerStats towerStats;
    public GameStatsScriptableObject GameStats;

    public event System.Action<int> OnMoneyChanged;

    public int GetStartMoney()
    {
        return StartMoney;
    }

    public bool BuyTower()
    {
        string strTowerName = BuildManager.Instance.GetCurTower();
        int cost = towerStats.GetTowerCost(strTowerName, 0);
        if (m_CurMoney < cost || cost == -1)
            return false;

        m_CurMoney -= cost;
        if(OnMoneyChanged != null)
            OnMoneyChanged(m_CurMoney);
        return true;
    }

    public bool IsTowerBuyable()
    {
        string strTowerName = BuildManager.Instance.GetCurTower();
        int cost = towerStats.GetTowerCost(strTowerName, 0);
        if (cost != -1)
        {
            if (cost <= m_CurMoney)
                return true;
            else
                return false;
        }
        return false;
    }

    public void EarnMoney(int amount)
    {
        m_CurMoney += amount;
        if (OnMoneyChanged != null)
            OnMoneyChanged(m_CurMoney);
    }

    public bool UpdateTower(int updatecost)
    {
        if (m_CurMoney < updatecost)
            return false;

        m_CurMoney -= updatecost;
        if (OnMoneyChanged != null)
            OnMoneyChanged(m_CurMoney);
        return true;
    }
}
