using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuCanvas : MonoBehaviour
{
    public TMP_InputField playerNameInput; // Input field for entering the player's name
    public TMP_Text bestScoreText; // Text field to display the highest score

    void Start()
    {
        if (playerNameInput == null || bestScoreText == null)
        {
            Debug.LogError("PlayerNameInput or BestScoreText is not assigned.");
            return;
        }

        LoadBestScore();

    }

    void Update()
    {
        // Check for spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        string playerName = playerNameInput.text.Trim();
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Player name cannot be empty.");
            return;
        }

        PlayerPrefs.SetString("CurrentPlayerName", playerName);
        SceneManager.LoadScene(1); // Ensure index or name is correct
    }

    public void LoadBestScore()
    {
        string playerName = PlayerPrefs.GetString("BestPlayerName", "Unknown");
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + bestScore + " Name: " + playerName;
    }

    public void SaveBestScore(int score, string playerName)
    {
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.SetString("BestPlayerName", playerName);
    }


    public void Quit()
    {
        // Quit the application
        Application.Quit();
    }
}
