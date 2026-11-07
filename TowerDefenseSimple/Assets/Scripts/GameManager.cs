using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

#if UNITY_EDITOR
        // Debug shortcut: end the game instantly (Editor only, not in builds)
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
#endif

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        //yield return new WaitForSeconds(2);
        StartCoroutine(Wait());
    }

    public void WinLevel()
    {
        // Debug.Log("Level Won!");
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
    }
}
