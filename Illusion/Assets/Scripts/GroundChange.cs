using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChange : MonoBehaviour
{
    private Animator groundAnimator;

    private void Start()
    {
        groundAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            groundAnimator.SetBool("IsAppearing", false);
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "InvisablePlatform")
        {
            groundAnimator.SetBool("IsAppearing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            groundAnimator.SetBool("IsAppearing", true);
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "InvisablePlatform")
        {
            groundAnimator.SetBool("IsAppearing", false);
        }
    }
}
