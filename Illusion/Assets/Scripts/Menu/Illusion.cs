using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illusion : MonoBehaviour
{
    private void OnMouseEnter()
    {
        gameObject.GetComponent<Animator>().SetBool("IsAppearing", false);
    }
}
