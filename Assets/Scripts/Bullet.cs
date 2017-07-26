using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyByTimeCO());
    }

    private void Update ()
    {
        this.transform.Translate(this.transform.forward * (-30) * Time.deltaTime);
    }

    private IEnumerator DestroyByTimeCO()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
