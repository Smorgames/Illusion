using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlayerMove : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(WaitBeforeComeIn(false, collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(WaitBeforeComeIn(true, collision));
        }
    }

    IEnumerator WaitBeforeComeIn(bool direction, Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        collision.GetComponent<PlayerMoveController>().ReverseHorizontalMove(direction);
    }
}
