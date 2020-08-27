using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ton : MonoBehaviour
{
    private Animator groundAnimator;

    private void Start()
    {
        groundAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //groundAnimator.SetBool("IsAppearing", false);
            StartCoroutine(Manager(false, 5));
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //groundAnimator.SetBool("IsAppearing", true);
            StartCoroutine(Manager(true, 2));
        }

    }

    IEnumerator Manager(bool isAppearing, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        groundAnimator.SetBool("IsAppearing", isAppearing);
    }
}
