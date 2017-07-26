using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MovePlayer refMP;
    private SoundManager refSM;
    public GameObject panelGameOver, panelFinishedLevel;
    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;

    private void Start()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refSM = FindObjectOfType<SoundManager>();
        refMP.delGameOver = GameOver;
        refMP.delFinishLevel = FinishedLevel;
    }

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

    public void Restart()
    {
        SceneManager.LoadScene("Circuit 1");
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
