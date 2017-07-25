using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    public bool isMovingLane = false;
    public int numLane = 0;
    public float speed;
    private float x0, x1, x2, xless1, xless2;

    private SoundManager refSM;
    private Rigidbody rb;

    public KeyCode moveR, moveL;

    public Action<int> delCurrentLane;

    private void Start()
    {
        refSM = FindObjectOfType<SoundManager>();
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
            delCurrentLane(numLane);
            ChangeLane(numLane);
        }

        if (Input.GetKeyDown(moveR) && !isMovingLane && numLane < 2)
        {
            numLane++;
            delCurrentLane(numLane);
            ChangeLane(numLane);
        }
    }

    private void ChangeLane(int _numLane)
    {
        isMovingLane = true;

        switch (_numLane)
        {
            case 0:
                this.transform.position = new Vector3(x0, this.transform.position.y, this.transform.position.z);
                break;
            case 1:
                this.transform.position = new Vector3(x1, this.transform.position.y, this.transform.position.z);
                break;
            case 2:
                this.transform.position = new Vector3(x2, this.transform.position.y, this.transform.position.z);
                break;
            case -1:
                this.transform.position = new Vector3(xless1, this.transform.position.y, this.transform.position.z);
                break;
            case -2:
                this.transform.position = new Vector3(xless2, this.transform.position.y, this.transform.position.z);
                break;
        }


        isMovingLane = false;
    }
}
