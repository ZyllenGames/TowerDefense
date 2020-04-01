using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterManager : MonoBehaviour
{
    public static MasterManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LevelCompleteState = new bool[5];
            for (int i = 0; i < LevelCompleteState.Length; i++)
            {
                LevelCompleteState[i] = false;
            }
            LevelCompleteState[0] = true;
        }
    }

    public bool[] LevelCompleteState;
    public GameObject WinningPrefab;
    public Vector3 WinningPosition = new Vector3(0, 0, 0);
    float m_WinningCelebrationTime = 3f;


    public void SetSceneComplete(string scenename)
    {
        Time.timeScale = 1;
        int sceneIndex = int.Parse(scenename.Remove(0, 5));
        if(sceneIndex < LevelCompleteState.Length)
        {
            LevelCompleteState[sceneIndex] = true;
            string nextscenename = "Level" + (sceneIndex + 1).ToString();

            StartCoroutine(SceneChange(nextscenename, true));
        }
        else
        {
            StartCoroutine(SceneChange("MainMenu", true));
        }
    }

    public IEnumerator SceneChange(string scenename, bool IsInterLevelChange)
    {
        if (IsInterLevelChange)
            yield return StartCoroutine(LevelComplete());
        float fadetime = SceneChangeControll.Instance.FadeTime;
        SceneChangeControll.Instance.LevelEnd();
        yield return new WaitForSeconds(fadetime);
        SceneManager.LoadScene(scenename);
        SceneChangeControll.Instance.LevelStart();
        yield return new WaitForSeconds(fadetime);
    }

    IEnumerator LevelComplete()
    {
        GameObject newWinning = Instantiate(WinningPrefab, WinningPosition, Quaternion.identity);
        yield return new WaitForSeconds(m_WinningCelebrationTime);
        Destroy(newWinning);
    }

    public void Lose()
    {
        Time.timeScale = 1;
        StartCoroutine(SceneFail());
    }

    IEnumerator SceneFail()
    {
        float duration = 2f;
        SceneChangeControll.Instance.LevelFailed();
        yield return new WaitForSeconds(duration);
        SceneChangeControll.Instance.Restart();
        yield return StartCoroutine(SceneChange("MainMenu", false));
    }
}
