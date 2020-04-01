using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuControll : MonoBehaviour
{
    public GameObject StartMenuObject;
    public GameObject LevelMenuObject;
    public Button[] LevelButtons;

    public void OnStartButtonPressed()
    {
        StartMenuObject.SetActive(false);
        LevelMenuObject.SetActive(true);

        bool[] levelstates = MasterManager.Instance.LevelCompleteState;
        for (int i = 0; i < levelstates.Length; i++)
        {
            if (levelstates[i])
                LevelButtons[i].interactable = true;
            else
                LevelButtons[i].interactable = false;
        }
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnLevel1ButtonPressed()
    {
        StartCoroutine(MasterManager.Instance.SceneChange("Level1", false));
    }

    public void OnLevel2ButtonPressed()
    {
        StartCoroutine(MasterManager.Instance.SceneChange("Level2", false));
    }

    public void OnLevel3ButtonPressed()
    {
        StartCoroutine(MasterManager.Instance.SceneChange("Level3", false));
    }

    public void OnLevel4ButtonPressed()
    {
        StartCoroutine(MasterManager.Instance.SceneChange("Level4", false));
    }

    public void OnLevel5ButtonPressed()
    {
        StartCoroutine(MasterManager.Instance.SceneChange("Level5", false));
    }
}
