using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private GameObject GameStartPanel;
    [SerializeField]
    private TextMeshProUGUI scoreText,scoreText1;
    [SerializeField]
    private GameObject GameOverPanel;
    public int score;

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
