using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "FINAL SCORE: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
