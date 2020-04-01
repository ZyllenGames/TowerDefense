using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public Text CurMoneyText;
    public Text CurLifeText;
    public Text CurWave;


    private void Start()
    {
        CurMoneyText.text = string.Format("{0:D4}", MoneyManager.Instance.GetStartMoney());
        MoneyManager.Instance.OnMoneyChanged += OnMoneyChanged;

        BaseBuilding bb = FindObjectOfType<BaseBuilding>();
        CurLifeText.text = "LIFE: " + bb.StartHealth.ToString();
        bb.OnHealthChanged += OnHealthChanged;

        Scene scene = SceneManager.GetActiveScene();
        CurWave.text = scene.name + "\r\nWave: " + "01" + " / " + EnemySpawner.Instance.TotalWaveNum.ToString();
        EnemySpawner.Instance.WaveChange += OnWaveChange;
    }

    void OnMoneyChanged(int money)
    {
        CurMoneyText.text = string.Format("{0:D4}", money); 
    }

    void OnHealthChanged(float health)
    {
        CurLifeText.text = "LIFE: " + health.ToString();
    }

    void OnWaveChange(int waveIndex)
    {
        Scene scene = SceneManager.GetActiveScene();
        CurWave.text = scene.name + "\r\nWave: " + string.Format("{0:D2}", waveIndex+1) + " / " + EnemySpawner.Instance.TotalWaveNum.ToString();
    }
}
