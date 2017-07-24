using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public KeyCode moveR, moveL;
    private Rigidbody rb;
    public bool isMovingLane = false;
    public int numLane = 0;
    //public float velHoriz = 0f;
    public float speed;
    private Vector3 myPosition;

    public Transform lane_0, lane_1, lane_2, lane_less_1, lane_less_2;
    public float x0, x1, x2, xless1, xless2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        x0 = lane_0.localPosition.x;
        x1 = lane_1.localPosition.x;
        x2 = lane_2.localPosition.x;
        xless1 = lane_less_1.localPosition.x;
        xless2 = lane_less_2.localPosition.x;
    }

    private void Update()
    {
       
        rb.velocity = this.transform.forward + new Vector3(0, 0, -speed);

        if (Input.GetKeyDown(moveL) && !isMovingLane && numLane > -2)
        {
            numLane--;
            ChangeLane(numLane);
        }

        if (Input.GetKeyDown(moveR) && !isMovingLane && numLane < 2)
        {
            numLane++;
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
