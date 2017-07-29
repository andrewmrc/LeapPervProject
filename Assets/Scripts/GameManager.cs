using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private MovePlayer refMP;
    private CollisionPlayer refCP;
    private SoundManager refSM;
    public GameObject panelGameOver, panelFinishedLevel;
    public Text scoreGO, scoreFL;
    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;


    public GameObject scorePoint;
    public TextMesh textScorePlayer;
    public int currentScore;

    // Assign delegates to their methods
    private void Awake()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refSM = FindObjectOfType<SoundManager>();
        refCP = FindObjectOfType<CollisionPlayer>();
        refCP.delGameOver = GameOver;
        refCP.delFinishLevel = FinishedLevel;
        refCP.delCondom = Condom;
        refCP.delBat = Bat;
        refCP.delHandcuff = Handcuff;
        refCP.delMouth = Mouth;
        refCP.delMuzzle = Muzzle;
        StartCoroutine(DistanceScore());
    }

    private void Update()
    {
        scorePoint.GetComponentInChildren<Text>().text = currentScore.ToString();
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

    // Increment score based to distance of the player and 
    //set it to text in 2 panel of Game Over and Finished Level
    private IEnumerator DistanceScore()
    {
        while (Time.timeScale == 1)
        {
            currentScore += ((int)refMP.transform.position.z * -1) * (int)refMP.speed;
            scoreGO.text = "Your score: " + currentScore.ToString();
            scoreFL.text = "Your final score: " + currentScore.ToString();
            yield return new WaitForSecondsRealtime(.1f);
        }
    }

    // Show green plus score feedback
    private IEnumerator FeedbackBonusCO(float _value)
    {
        textScorePlayer.gameObject.SetActive(true);
        textScorePlayer.color = Color.green;

        float initialY = textScorePlayer.transform.position.y;

        while (textScorePlayer.transform.position.y <= 25f)
        {
            textScorePlayer.transform.position += new Vector3(0f, .5f, 0f);
            textScorePlayer.text = "+ " + _value.ToString();
            //textScorePlayer.GetComponent<TextMesh>().color.a += 0.4 * Time.deltaTime; ;
            yield return null;
        }

        textScorePlayer.gameObject.SetActive(false);
        textScorePlayer.transform.position = new Vector3(textScorePlayer.transform.position.x, initialY, textScorePlayer.transform.position.z);
    }

    // Show red minus score feedback
    private IEnumerator FeedbackMalusCO(float _value)
    {
        textScorePlayer.gameObject.SetActive(true);
        textScorePlayer.color = Color.red;

        float initialY = textScorePlayer.transform.position.y;

        while (textScorePlayer.transform.position.y <= 25f)
        {
            textScorePlayer.transform.position += new Vector3(0f, .5f, 0f);
            textScorePlayer.text = "- " + _value.ToString();
            //textScorePlayer.GetComponent<TextMesh>().color.a += 0.4 * Time.deltaTime; ;
            yield return null;
        }

        textScorePlayer.gameObject.SetActive(false);
        textScorePlayer.transform.position = new Vector3(textScorePlayer.transform.position.x, initialY, textScorePlayer.transform.position.z);
    }

#region DelegatesMethods

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

    // Called when take a Condom, change score of value passed by delegate
    private void Condom(int _value, string _name)
    {
        switch (_name)
        {
            case "Penis":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
            case "Vagina":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
            case "Ass":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
        }
    }

    // Called when take a Bat, change score of value passed by delegate
    private void Bat(int _value, string _name)
    {
        switch (_name)
        {
            case "Penis":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
            case "Vagina":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
            case "Ass":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
        }
    }


    private void Handcuff(int _value, string _name)
    {
        switch (_name)
        {
            case "Penis":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
            case "Vagina":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
            case "Ass":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
        }
    }

    private void Mouth(int _value, string _name)
    {
        switch (_name)
        {
            case "Penis":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
            case "Vagina":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
            case "Ass":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
        }
    }

    private void Muzzle(int _value, string _name)
    {
        switch (_name)
        {
            case "Penis":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
            case "Vagina":
                currentScore -= _value;
                StartCoroutine(FeedbackMalusCO(_value));
                break;
            case "Ass":
                currentScore += _value;
                StartCoroutine(FeedbackBonusCO(_value));
                break;
        }
    }
    #endregion
}
