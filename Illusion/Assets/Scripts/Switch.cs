using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject stick;
    public GameObject floor;

    private GameObject player;

    private bool switchRegulator1 = false, switchRegulator2 = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Switch")
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                stick.GetComponent<Animator>().SetBool("Disappear", true);
                if (switchRegulator1 == false)
                {
                    player.GetComponent<Sound>().SwitchSound();
                    switchRegulator1 = true;
                }
            }

            if (gameObject.tag == "FalseSwitch")
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                if (switchRegulator2 == false)
                {
                    player.GetComponent<Sound>().SwitchSound();
                    switchRegulator2 = true;
                }
                StartCoroutine(FloorGang());
            }
        }
    }

    IEnumerator FloorGang()
    {
        yield return new WaitForSeconds(1);
        floor.GetComponent<BoxCollider2D>().enabled = false;
    }
}
