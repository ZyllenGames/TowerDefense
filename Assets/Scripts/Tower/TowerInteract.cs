using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInteract : MonoBehaviour
{
    private void OnMouseDown()
    {
        string name = GetComponent<Tower>().TowerData.Name;
        int level = GetComponent<Tower>().TowerData.Level;
        TowerInfoUI.Instance.ShowInfo(name, level, gameObject);
    }
}
