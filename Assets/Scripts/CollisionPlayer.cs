using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionPlayer : MonoBehaviour
{
    public Action<int, string> delCondom;
    public Action<int, string> delBat;
    public Action<int, string> delHandcuff;
    public Action<int, string> delMouth;
    public Action<int, string> delMuzzle;
    public Action<int, string> delUnderwear;
    public Action<int, string> delPill;
    public Action<bool> delGameOver;
    public Action<bool> delFinishLevel;


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
            Debug.Log("Delegato Bat");
        }

        if (collision.gameObject.name == "Handcuff")
        {
            delHandcuff(300, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Handcuff");
        }

        if (collision.gameObject.name == "Mouth")
        {
            delMouth(600, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Mouth");
        }

        if (collision.gameObject.name == "Muzzle")
        {
            delMuzzle(400, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Muzzle");
        }

        if (collision.gameObject.name == "Underwear")
        {
            delUnderwear(500, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Underwear");
        }

        if (collision.gameObject.name == "Pill")
        {
            delPill(900, this.gameObject.name);
            Destroy(collision.gameObject);
            Debug.Log("Delegato Pill");
        }

        if (collision.gameObject.name == "Dick Pig")
        {
            delGameOver(true);
            Debug.Log("Delegato GameOver");
        }
    }
}
