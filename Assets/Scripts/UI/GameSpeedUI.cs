using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSpeedUI : MonoBehaviour
{
    public Text FastText;
    public Text PauseText;

    bool m_isFast = false;
    bool m_isPaused = false;

    public void OnFastButtonPressed()
    {
        if(!m_isFast)
        {
            FastText.text = "X1";
            Time.timeScale = 2;
            m_isFast = true;
        }
        else
        {
            FastText.text = "X2";
            Time.timeScale = 1;
            m_isFast = false;
        }
    }

    public void OnPauseButtonPressed()
    {
        if (!m_isPaused)
        {
            PauseText.text = ">";
            Time.timeScale = 0;
            m_isPaused = true;
        }
        else
        {
            PauseText.text = "II";
            Time.timeScale = 1;
            m_isPaused = false;
        }
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
