using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoors : MonoBehaviour
{
    private GameObject player;
    private GameObject quad;
    private Animator quadAnimator;

    public GameObject spawnBlock;
    public GameObject fantomDoor;

    public GameObject falseFloor;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        quad = GameObject.FindWithTag("Quad");
        quadAnimator = quad.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ExitDoor1());
        }
    }

    IEnumerator ExitDoor1()
    {
        player.GetComponent<Sound>().CreepySound();
        quadAnimator.SetBool("Change", true);
        spawnBlock.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<PlayerMoveController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        quadAnimator.SetBool("Change", false);
        player.GetComponent<PlayerMoveController>().enabled = true;
        player.transform.position = new Vector3(-9.356f, 4.024f, 0.0f);
        yield return new WaitForSeconds(1.5f);
        spawnBlock.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(false);
        Instantiate(fantomDoor, transform.position, Quaternion.identity);
        falseFloor.SetActive(false);
    }
}
