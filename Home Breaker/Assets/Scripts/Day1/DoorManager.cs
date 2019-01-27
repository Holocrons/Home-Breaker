using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject otherDoor;
    public int destination;
    public bool e = false;
    public GameObject info;

    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("objinfo");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && e == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ok");
            Camera.main.GetComponent<CameraManager>().PlayClip(1, 40f);
            if (otherDoor != null)
                collision.transform.position = otherDoor.transform.position;
            collision.GetComponent<PlayerMovement>().currentsScene = destination;
            collision.GetComponent<PlayerMovement>().timer = Time.time + 0.1f;
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
        else if (e == true && collision.tag == "Player")
        {
            info.GetComponentsInChildren<Transform>(true)[1].gameObject.SetActive(true);
            info.GetComponentsInChildren<Transform>(true)[1].gameObject.GetComponent<TextMesh>().text = name;
            info.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + 2, 0);
            if (name == "school")
                info.transform.position = new Vector3(transform.position.x + 1, Camera.main.transform.position.y + 2, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            info.GetComponentsInChildren<Transform>(true)[1].gameObject.SetActive(false);
        }
    }
}
