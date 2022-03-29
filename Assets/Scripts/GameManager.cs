using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameStartPanel;
    public static int score;
    public TextMeshProUGUI scoreText,scoreText1;
    public GameObject GameOverPanel;
    private void Start()
    {
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        StartCoroutine(GameComplete());
        Debug.Log("GameOver");
    }
    private void Update()
    {
        scoreText.text = "SCORE - " + score.ToString();
        scoreText1.text = scoreText.text;
    }
    IEnumerator GameComplete()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameOverPanel.SetActive(true);

    }
    public void Lobby()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
