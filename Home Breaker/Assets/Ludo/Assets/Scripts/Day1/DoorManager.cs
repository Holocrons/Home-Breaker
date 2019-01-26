using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject otherDoor;
    public int destination;
    public bool e = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && e == true && Input.GetKeyDown(KeyCode.E))
        {
            collision.transform.position = otherDoor.transform.position;
            collision.GetComponent<PlayerMovement>().currentsScene = destination;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && e == false && collision.GetComponent<PlayerMovement>().timer <= Time.time)
        {
            collision.transform.position = otherDoor.transform.position;
            collision.GetComponent<PlayerMovement>().currentsScene = destination;
            collision.GetComponent<PlayerMovement>().timer = Time.time + 0.1f;
        }
    }
}
