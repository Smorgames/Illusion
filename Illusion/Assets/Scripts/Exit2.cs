using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit2 : MonoBehaviour
{
    public GameObject falseFloor2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FalseFloor());
        }
    }

    IEnumerator FalseFloor()
    {
        yield return new WaitForSeconds(1);
        falseFloor2.SetActive(true);
    }
}
