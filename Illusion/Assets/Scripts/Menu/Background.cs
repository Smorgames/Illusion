using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if (transform.position.x <= -25.65f)
            transform.position = new Vector3(34.88f, 0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
