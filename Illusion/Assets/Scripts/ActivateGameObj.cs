using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObj : MonoBehaviour
{
    public GameObject objectNeedToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            objectNeedToActivate.SetActive(true);
    }
}
