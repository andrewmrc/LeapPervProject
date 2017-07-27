﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    public bool isMovingLane = false;
    public int numLane = 0;
    public float speed;
    public byte velTurn;
    private float x0, x1, x2, xless1, xless2;
    private GameManager refGM;
    private Rigidbody rb;
    private Animator anim;

    public KeyCode moveR, moveL;

    public Action<int> delCurrentLane;
    public Action<int, string> delCondom;
    public Action<int, string> delBat;
    public Action<bool> delGameOver;
    public Action<bool> delFinishLevel;

    private void Start()
    {
        refGM = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Take x values from the public transform in Game Manager
        x0 = refGM.lane_0.localPosition.x;
        x1 = refGM.lane_1.localPosition.x;
        x2 = refGM.lane_2.localPosition.x;
        xless1 = refGM.lane_less_1.localPosition.x;
        xless2 = refGM.lane_less_2.localPosition.x;
    }

    private void Update()
    {
        // Move forward the player
        transform.Translate(transform.forward * (-speed) * Time.deltaTime);

        // If i move left
        if (Input.GetKeyDown(moveL) && !isMovingLane && numLane > -2)
        {
            numLane--;
            anim.SetBool("isTurnLeft", true);
            delCurrentLane(numLane);
            ChangeLane(numLane);
            StartCoroutine(SetFalseBool("isTurnLeft"));
        }

        // If i move right
        if (Input.GetKeyDown(moveR) && !isMovingLane && numLane < 2)
        {
            anim.SetBool("isTurnRight", true);
            numLane++;
            delCurrentLane(numLane);
            ChangeLane(numLane);
            StartCoroutine(SetFalseBool("isTurnRight"));
        }
    }

    // Method called for switch lane
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

    // Coroutine that set bool true, change the lane, and set bool false
    private IEnumerator SwitchLaneCO(float _x)
    {
        isMovingLane = true;
        while (this.transform.position.x != _x)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(_x, this.transform.position.y, this.transform.position.z), Time.deltaTime * velTurn);
        }
        isMovingLane = false;
    }

    // Coroutine for set false bool in animator with a little dealy
    private IEnumerator SetFalseBool(string _bool)
    {
        yield return null;
        anim.SetBool(_bool, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            delGameOver(true);
            Debug.Log("Delegato GameOver");
        }

        if (collision.gameObject.name == "EndTrack")
        {
            delFinishLevel(true);
            Debug.Log("Delegato Finish Level");
        }

        if (collision.gameObject.name == "Condom")
        {
            delCondom(250, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Condom");
        }

        if (collision.gameObject.name == "Bat")
        {
            delBat(500, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Condom");
        }
    }
}
