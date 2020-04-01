using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoUI : MonoBehaviour
{
    public static TowerInfoUI Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Vector3 HoverOffset = new Vector3(0, 5, 1);

    public Text UpgradeText;
    public Text SellText;


    int m_UpgradeCost = 0;
    int m_SellMoney = 0;
    GameObject m_UpgradePrefab = null;
    GameObject CurTower;

    public SOTowerStats towerStats;
    public void OnUpgradeButton()
    {
        if(m_UpgradePrefab != null)
        {
            if(MoneyManager.Instance.UpdateTower(m_UpgradeCost))
                BuildManager.Instance.UpdateTower(CurTower, m_UpgradePrefab);
        }
        HideInfo();
    }

    public void OnSellButton()
    {
        BuildManager.Instance.SellTower(CurTower);
        MoneyManager.Instance.EarnMoney(m_SellMoney);
        HideInfo();
    }

    public void ShowInfo(string name, int level, GameObject tower)
    {
        transform.position = tower.transform.position + HoverOffset;
        if(transform.GetChild(0).gameObject.activeSelf == true)
            transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);

        towerStats.GetTowerInfo(name, level, out m_UpgradeCost, out m_SellMoney, ref m_UpgradePrefab);
        if(level != 2)
        {
            UpgradeText.text = "$" + m_UpgradeCost.ToString();
            SellText.text = "$" + m_SellMoney.ToString();
        }
        else
        {
            UpgradeText.text = "Top";
            SellText.text = "$" + m_SellMoney.ToString();
            m_UpgradePrefab = null;
        }

        CurTower = tower;
    }

    void HideInfo()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
