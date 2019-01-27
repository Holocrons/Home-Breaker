using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        }
    }

}
