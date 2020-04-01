using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool m_HasTower = false;

    public Color HoverColor = Color.yellow;
    public Color NotBuyableColor = Color.red;
    private Color m_StartColor;

    private void Awake()
    {
        m_StartColor = GetComponent<Renderer>().material.color;
    }

    private void OnMouseDown()
    {
        if (!m_HasTower && BuildManager.Instance.GetCurTower() != "")
        {
            if (MoneyManager.Instance.BuyTower())
            {
                BuildManager.Instance.BuildTower(transform.position + new Vector3(0f, 0.5f, 0f), this);
                m_HasTower = true;
                BuildManager.Instance.SetCurTower("");
            }
        }
    }

    private void OnMouseEnter()
    {
        if(!m_HasTower && BuildManager.Instance.GetCurTower() != "")
        {
            if(MoneyManager.Instance.IsTowerBuyable())
                GetComponent<Renderer>().material.color = HoverColor;
            else
                GetComponent<Renderer>().material.color = NotBuyableColor;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = m_StartColor;
    }
}
