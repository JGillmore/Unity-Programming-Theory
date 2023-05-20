using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int gameDifficulty { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetDifficulty(int difficulty)
    {
        if (difficulty < 1 || difficulty > 3)
        {
            Debug.LogError("Game difficulty must be between 1 and 3 (Easy, Med, Hard)");
            return;
        }
        gameDifficulty = difficulty;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
