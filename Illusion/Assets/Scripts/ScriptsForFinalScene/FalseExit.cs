using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseExit : MonoBehaviour
{
    private Animator exitDoorAnimator;

    public GameObject falseExit2;
    private Animator falseExit2Animator;

    public GameObject falseFloor;

    private void Start()
    {
        exitDoorAnimator = gameObject.GetComponent<Animator>();
        falseExit2Animator = falseExit2.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ExitDoorManager());
        }
    }

    IEnumerator ExitDoorManager()
    {
        exitDoorAnimator.SetBool("IsAppearing", false);
        falseExit2Animator.SetBool("IsAppearing", true);
        falseFloor.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
