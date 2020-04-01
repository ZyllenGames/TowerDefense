using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject[] EnemyPrefabs;

    public float TimeBetweenSpawn = 1f;
    public int StartWaveEnemyNum = 5;
    public int TotalWaveNum = 10;

    [SerializeField]
    private int m_curWaveEnemyNum;
    [SerializeField]
    private int m_CurWaveEnemyDeadNum;

    public event System.Action<int> WaveChange;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        Enemy.EnemyKilled += OneEnemyKilled;
    }
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < TotalWaveNum; i++)
        {
            if(WaveChange != null)
                WaveChange(i);

            m_CurWaveEnemyDeadNum = 0;
            yield return StartCoroutine(SpawnOneWave(i));
            
            //Wait for Cur Wave Enemy All Dead
            while(true)
            {
                if (m_curWaveEnemyNum == m_CurWaveEnemyDeadNum)
                    break;
                else
                    yield return null;
            }
        }

        //Level Completed!!!
        MasterManager.Instance.SetSceneComplete(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnOneWave(int WaveIndex)
    {
        m_curWaveEnemyNum = WaveIndex + StartWaveEnemyNum;
        int EnemyPrefabsIndex = Random.Range(0, EnemyPrefabs.Length);
        Color newColor = Random.ColorHSV(0f, 0.5f, 0.3f, 0.6f, 0.8f, 0.9f);
        for (int i = 0; i < m_curWaveEnemyNum; i++)
        {
            GameObject newEnemy = Instantiate(EnemyPrefabs[EnemyPrefabsIndex], transform.position, transform.rotation);
            newEnemy.GetComponent<Enemy>().RaiseStats(WaveIndex, WaveIndex);
            newEnemy.transform.parent = transform;
            newEnemy.GetComponent<Renderer>().material.color = newColor;

            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
    }

    void OneEnemyKilled()
    {
        m_CurWaveEnemyDeadNum++;
    }

    private void OnDestroy()
    {
        Enemy.EnemyKilled -= OneEnemyKilled;
    }
}
