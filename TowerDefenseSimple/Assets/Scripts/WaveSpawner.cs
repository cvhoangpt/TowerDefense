using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeEachWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //SpawnWave();
            countdown = timeEachWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //Xu ly hieu ung ve thoi gian
        //  waveCountdownText.text = Mathf.Round(countdown).ToString();
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    //This method to describe one wave game
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        //Debug.Log("Wave Incoming...");
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
