using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();    
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Go to Menu.");
    }
}
