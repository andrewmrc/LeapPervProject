using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private MovePlayer refMP;
    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;
    public AudioClip[] audioClipArray;
    public Transform[] laneArray = new Transform[4];
    public AudioSource audioSoundManager;

    public int currIndexAudioClipArray;

    private void Awake()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refMP.delCurrentLane = PlaySingleTrack;
        audioSoundManager = GetComponent<AudioSource>();

        laneArray[0] = lane_1;
        laneArray[1] = lane_2;
        laneArray[2] = lane_less_1;
        laneArray[3] = lane_less_2;

        SetAudioClip();
        StartCoroutine(ChangeAudioClipCO());
    }

    private void PlaySingleTrack(int _numLane)
    {
        switch (_numLane)
        {
            case 0:
                StartCoroutine(IncreaseVolumeCO(lane_0));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 1:
                StartCoroutine(IncreaseVolumeCO(lane_1));

                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 2:
                StartCoroutine(IncreaseVolumeCO(lane_2));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case -1:
                StartCoroutine(IncreaseVolumeCO(lane_less_1));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));

                break;
            case -2:
                StartCoroutine(IncreaseVolumeCO(lane_less_2));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_0));
                break;
        }
    }

    private IEnumerator IncreaseVolumeCO(Transform _lane)
    {
        _lane.GetComponent<AudioSource>().volume = 1;
        yield return null;
    }

    private IEnumerator DecreaseVolumeCO(Transform _lane)
    {
        while (_lane.GetComponent<AudioSource>().volume != 0)
        {
            yield return null;
            _lane.GetComponent<AudioSource>().volume -= .05f;

        }
    }

    private void SetAudioClip()
    {
        foreach (var lane in laneArray)
        {
            for (int i = currIndexAudioClipArray; i < currIndexAudioClipArray + 1; i++)
            {
                lane.GetComponent<AudioSource>().clip = audioClipArray[i];
                lane.GetComponent<AudioSource>().Play();
            }
            currIndexAudioClipArray++;
        }
    }

    private IEnumerator ChangeAudioClipCO()
    {
        yield return new WaitForSeconds(14f);
        SetAudioClip();
    }
}
