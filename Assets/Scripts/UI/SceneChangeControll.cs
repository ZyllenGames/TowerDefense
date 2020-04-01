using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeControll : MonoBehaviour
{
    public static SceneChangeControll Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        FadeInImage.SetActive(false);
        FadeOutImage.SetActive(false);
    }

    public GameObject FadeInImage;
    public GameObject FadeOutImage;
    public GameObject FailImage;
    public float FadeTime = 1f;

    public void LevelStart()
    {
        FadeInImage.SetActive(true);
        FadeOutImage.SetActive(false);
    }
    public void LevelEnd()
    {
        FadeOutImage.SetActive(true);
        FadeInImage.SetActive(false);
    }

    public void LevelFailed()
    {
        FailImage.SetActive(true);
    }
    public void Restart()
    {
        FailImage.SetActive(false);
    }
}
