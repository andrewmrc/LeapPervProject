using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private MovePlayer refMP;
    private SoundManager refSM;
    public GameObject panelGameOver, panelFinishedLevel;
    public Text scoreGO, scoreFL;
    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;

    public GameObject scorePoint;
    public float currentScore;

    // Assign delegates to their methods
    private void Start()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refSM = FindObjectOfType<SoundManager>();
        refMP.delGameOver = GameOver;
        refMP.delFinishLevel = FinishedLevel;

        StartCoroutine(DistanceScore());
    }

    private void Update()
    {
        scorePoint.GetComponentInChildren<Text>().text = currentScore.ToString();
    }

    // Stop all music, active panel Finish Level and play sound
    private void FinishedLevel(bool _on)
    {
        Time.timeScale = 0;

        for (int i = 0; i < refSM.laneArray.Length; i++)
        {
            refSM.laneArray[i].GetComponent<AudioSource>().Stop();
        }

        panelFinishedLevel.SetActive(_on);
        panelFinishedLevel.GetComponent<AudioSource>().Play();
    }

    // Stop all music, active panel Game Over and play sound
    private void GameOver(bool _on)
    {
        Time.timeScale = 0;

        for (int i = 0; i < refSM.laneArray.Length; i++)
        {
            refSM.laneArray[i].GetComponent<AudioSource>().Stop();
        }

        panelGameOver.SetActive(_on);
        panelGameOver.GetComponent<AudioSource>().Play();
    }

    // Method called by button for restart scene
    public void Restart()
    {
        SceneManager.LoadScene("Circuit 1");
        Time.timeScale = 1;
    }

    // Method called to return in main menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    // Increment score and set it to text in 2 panel of Game Over and Finished Level
    private IEnumerator DistanceScore()
    {
        while (Time.timeScale == 1)
        {
            currentScore += 15;
            scoreGO.text = "Your score: " + currentScore.ToString();
            scoreFL.text = "Your final score: " + currentScore.ToString();
            yield return new WaitForSecondsRealtime(.1f);
            yield return null;
        }
    }
}
