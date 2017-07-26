using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletSpawned = Instantiate(prefab);
            bulletSpawned.transform.position = this.transform.position;
        }
    }
}
