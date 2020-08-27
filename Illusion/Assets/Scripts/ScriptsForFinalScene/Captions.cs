using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Captions : MonoBehaviour
{
    public GameObject blackground;
    private GameObject player;

    public GameObject canvasVar;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CaptionsCoroutine());
        }
    }

    IEnumerator CaptionsCoroutine()
    {
        player.SetActive(false);
        blackground.GetComponent<Animator>().SetBool("IsAppearing", true);
        yield return new WaitForSeconds(1);
        canvasVar.SetActive(true);
    }
}
