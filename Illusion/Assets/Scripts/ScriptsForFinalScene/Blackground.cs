using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackground : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartAppear());
    }

    IEnumerator StartAppear()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Animator>().SetBool("IsAppearing", false);
    }
}
