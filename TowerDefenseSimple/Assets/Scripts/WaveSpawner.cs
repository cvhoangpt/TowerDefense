using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;
    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //SpawnWave();
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        // Xu ly hieu ung ve thoi gian
        //  waveCountdownText.text = Mathf.Round(countdown).ToString();
        waveCountdownText.text = string.Format("{0:00}", countdown);
    }

    //This method to describe one wave game
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        //Debug.Log("Wave Incoming...");
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
