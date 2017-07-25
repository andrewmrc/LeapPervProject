using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MovePlayer refMP;
    private SoundManager refSM;
    public GameObject panelGameOver;

    private void Start()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refSM = FindObjectOfType<SoundManager>();
        refMP.delGameOver = GameOver;
    }

    private void GameOver(bool _on)
    {
        Time.timeScale = 0;

        for (int i = 0; i < refSM.laneArray.Length; i++)
        {
            refSM.laneArray[i].GetComponent<AudioSource>().Stop();
        }

        refSM.audioSoundManager.Play();
        panelGameOver.SetActive(_on);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Circuit 1");
        Time.timeScale = 1;
    }
}
