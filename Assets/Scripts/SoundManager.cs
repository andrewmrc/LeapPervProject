using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private MovePlayer refMP;
    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;

    private void Start()
    {
        refMP = FindObjectOfType<MovePlayer>();
        refMP.delCurrentLane = PlaySingleTrack;
    }

    private void PlaySingleTrack(int _numLane)
    {
        switch (_numLane)
        {
            case 0:
                StartCoroutine(IncreaseVolumeCO(lane_0));

                StartCoroutine(DecreaseVolumeCO(lane_1));
                StartCoroutine(DecreaseVolumeCO(lane_2));
                StartCoroutine(DecreaseVolumeCO(lane_less_1));
                StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 1:
                StartCoroutine(IncreaseVolumeCO(lane_1));

                StartCoroutine(DecreaseVolumeCO(lane_0));
                StartCoroutine(DecreaseVolumeCO(lane_2));
                StartCoroutine(DecreaseVolumeCO(lane_less_1));
                StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case 2:
                StartCoroutine(IncreaseVolumeCO(lane_2));

                StartCoroutine(DecreaseVolumeCO(lane_1));
                StartCoroutine(DecreaseVolumeCO(lane_0));
                StartCoroutine(DecreaseVolumeCO(lane_less_1));
                StartCoroutine(DecreaseVolumeCO(lane_less_2));
                break;
            case -1:
                StartCoroutine(IncreaseVolumeCO(lane_less_1));

                StartCoroutine(DecreaseVolumeCO(lane_1));
                StartCoroutine(DecreaseVolumeCO(lane_2));
                StartCoroutine(DecreaseVolumeCO(lane_0));
                StartCoroutine(DecreaseVolumeCO(lane_less_2));

                break;
            case -2:
                StartCoroutine(IncreaseVolumeCO(lane_less_2));

                StartCoroutine(DecreaseVolumeCO(lane_1));
                StartCoroutine(DecreaseVolumeCO(lane_2));
                StartCoroutine(DecreaseVolumeCO(lane_less_1));
                StartCoroutine(DecreaseVolumeCO(lane_0));
                break;
        }
    }
    private IEnumerator IncreaseVolumeCO(Transform _lane)
    {
        _lane.GetComponent<AudioSource>().volume = 1;
        yield return null;
        //while (_lane.GetComponent<AudioSource>().volume != 1)
        //{
        //    yield return null;
        //    _lane.GetComponent<AudioSource>().volume += .1f;

        //}
    }
    private IEnumerator DecreaseVolumeCO(Transform _lane)
    {
        while (_lane.GetComponent<AudioSource>().volume != 0)
        {
            yield return null;
            _lane.GetComponent<AudioSource>().volume -= .05f;

        }
    }
}
