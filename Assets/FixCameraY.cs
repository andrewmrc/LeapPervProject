using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCameraY : MonoBehaviour
{
    private Transform initialPos;

    private void Awake()
    {
        initialPos.position = this.transform.position;
    }

    private void Update()
    {
        this.transform.position = initialPos.position;
    }
}
