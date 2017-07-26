﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private MovePlayer refMP;
    private GameManager refGM;
    public AudioClip[] audioClipArray;
    public Transform[] laneArray = new Transform[4];
    public AudioSource audioSoundManager;

    public int currIndexAudioClipArray;

    private void Awake()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refGM = FindObjectOfType<GameManager>();
        refMP.delCurrentLane = PlaySingleTrack;
        audioSoundManager = GetComponent<AudioSource>();

        laneArray[0] = refGM.lane_1;
        laneArray[1] = refGM.lane_2;
        laneArray[2] = refGM.lane_less_1;
        laneArray[3] = refGM.lane_less_2;

        SetAudioClip();
    }

    private void PlaySingleTrack(int _numLane)
    {
        switch (_numLane)
        {
            case 0:
                StartCoroutine(IncreaseVolumeCO(refGM.lane_0));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 1:
                StartCoroutine(IncreaseVolumeCO(refGM.lane_1));

                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 2:
                StartCoroutine(IncreaseVolumeCO(refGM.lane_2));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_less_1));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case -1:
                StartCoroutine(IncreaseVolumeCO(refGM.lane_less_1));

                //StartCoroutine(DecreaseVolumeCO(lane_1));
                //StartCoroutine(DecreaseVolumeCO(lane_2));
                //StartCoroutine(DecreaseVolumeCO(lane_0));
                //StartCoroutine(DecreaseVolumeCO(lane_less_2));

                break;
            case -2:
                StartCoroutine(IncreaseVolumeCO(refGM.lane_less_2));

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

    public void SetAudioClip()
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
