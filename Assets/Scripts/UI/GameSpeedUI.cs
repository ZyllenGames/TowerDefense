using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSpeedUI : MonoBehaviour
{
    bool IsFast = false;
    bool IsPause = false;
    public Text FastText;
    public Text PauseText;

    public void OnFastButtonPressed()
    {
        if(!IsFast)
        {
            FastText.text = "X1";
            Time.timeScale = 2;
            IsFast = true;
        }
        else
        {
            FastText.text = "X2";
            Time.timeScale = 1;
            IsFast = false;
        }
    }

    public void OnPauseButtonPressed()
    {
        if (!IsPause)
        {
            PauseText.text = ">";
            Time.timeScale = 0;
            IsPause = true;
        }
        else
        {
            PauseText.text = "II";
            Time.timeScale = 1;
            IsPause = false;
        }
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
