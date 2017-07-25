using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    private bool isMovingLane = false;
    public int numLane = 0;
    public float speed;
    private float x0, x1, x2, xless1, xless2;

    private SoundManager refSM;
    private Rigidbody rb;
    private Animator anim;

    public KeyCode moveR, moveL;

    public Action<int> delCurrentLane;

    private void Start()
    {
        refSM = FindObjectOfType<SoundManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        x0 = refSM.lane_0.localPosition.x;
        x1 = refSM.lane_1.localPosition.x;
        x2 = refSM.lane_2.localPosition.x;
        xless1 = refSM.lane_less_1.localPosition.x;
        xless2 = refSM.lane_less_2.localPosition.x;
    }

    private void Update()
    {     
        rb.velocity = this.transform.forward + new Vector3(0, 0, -speed);

        if (Input.GetKeyDown(moveL) && !isMovingLane && numLane > -2)
        {
            numLane--;
            anim.SetBool("isTurnLeft", true);
            delCurrentLane(numLane);
            ChangeLane(numLane);
            StartCoroutine(SetFalseBool("isTurnLeft"));
        }

        if (Input.GetKeyDown(moveR) && !isMovingLane && numLane < 2)
        {
            anim.SetBool("isTurnRight", true);
            numLane++;
            delCurrentLane(numLane);
            ChangeLane(numLane);
            StartCoroutine(SetFalseBool("isTurnRight"));
        }
    }

    private void ChangeLane(int _numLane)
    {
        switch (_numLane)
        {
            case 0:
                StartCoroutine(SwitchLaneCO(x0));
                break;
            case 1:
                StartCoroutine(SwitchLaneCO(x1));
                break;
            case 2:
                StartCoroutine(SwitchLaneCO(x2));
                break;
            case -1:
                StartCoroutine(SwitchLaneCO(xless1));
                break;
            case -2:
                StartCoroutine(SwitchLaneCO(xless2));
                break;
        }
    }

    private IEnumerator SwitchLaneCO(float _x)
    {
        isMovingLane = true;
        while (this.transform.position.x != _x)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(_x, this.transform.position.y, this.transform.position.z), Time.deltaTime * 7);
            yield return null;
        }
        isMovingLane = false;
    }

    private IEnumerator SetFalseBool(string _bool)
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool(_bool, false);

    }
}
