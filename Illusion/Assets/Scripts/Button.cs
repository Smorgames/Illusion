using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator buttonAnimator;
    private GameObject player;

    public GameObject firstBlock, secondBlock, chainLink;

    public GameObject quad, text_Not;
    private Animator quadAnimator, text_NotAnimator;

    public GameObject platformWhichWillDisappear;

    public GameObject bubbles, bubblesBlock;

    public GameObject floor;

    private void Start()
    {
        buttonAnimator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        quadAnimator = quad.GetComponent<Animator>();
        text_NotAnimator = text_Not.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Manager());
        }
    }

    IEnumerator Manager()
    {
        buttonAnimator.SetTrigger("IsPressed"); // click button animation
        player.GetComponent<Sound>().SwitchSound();
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // turn off button collider
        firstBlock.SetActive(true); // activate block
        secondBlock.SetActive(true); // activate block
        yield return new WaitForSeconds(1f);
        chainLink.SetActive(false); // break chain link
        player.GetComponent<Sound>().BreakChainLink(); // break chain link sound
        player.GetComponent<PlayerMoveController>().enabled = false; // turn off player move
        player.GetComponent<Sound>().TonFallSound();
        yield return new WaitForSeconds(1f);
        quadAnimator.SetTrigger("Appear");
        yield return new WaitForSeconds(2f);
        text_NotAnimator.SetTrigger("Appear");
        yield return new WaitForSeconds(2f);
        text_NotAnimator.SetTrigger("Disappear");
        quadAnimator.SetTrigger("Disappear");
        yield return new WaitForSeconds(2f);
        quad.SetActive(false);
        text_Not.SetActive(false);
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerMoveController>().enabled = true;
        yield return new WaitForSeconds(1f);
        platformWhichWillDisappear.GetComponent<BoxCollider2D>().enabled = false;
        floor.SetActive(false);
        bubbles.SetActive(true);
        bubblesBlock.SetActive(false);
    }
}
