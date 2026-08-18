using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_Text bestScoreText;

    private void Start()
    {
        // Load the High Score data when the menu opens
        int savedScore = PlayerPrefs.GetInt("BestScore", 0);
        string savedName = PlayerPrefs.GetString("BestName", "");

        if (savedScore > 0)
        {
            bestScoreText.text = $"Best Score : {savedName} : {savedScore}";
        }
        else
        {
            bestScoreText.text = "No Best Score Yet!";
        }
    }

    public void StartGame()
    {
        string name = playerNameInput.text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            name = "Player"; // Default name
        }

        // Save the current player's name so the game scene can read it
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();

        // Load the game scene (Make sure your scene name is "main")
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}