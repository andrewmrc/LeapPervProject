using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public byte speedBullet;
    private void Awake()
    {
        StartCoroutine(DestroyByTimeCO());
    }

    private void Update ()
    {
        this.transform.Translate(this.transform.forward * (-speedBullet) * Time.deltaTime);
    }

    private IEnumerator DestroyByTimeCO()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
