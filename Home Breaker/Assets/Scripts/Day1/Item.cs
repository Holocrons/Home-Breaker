using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public List<string> actions;
    public string look;
    public GameObject info;
    public GameObject miniItem;

    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("objinfo");
        Debug.Log(info.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Look()
    {
        GameObject tmp;

        tmp = GameObject.Find("Info");
        tmp.transform.position = new Vector3(Camera.main.transform.position.x - 3, Camera.main.transform.position.y + 2.5f, 0);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<InfoManager>().timer = Time.time + 3f;
        tmp.GetComponent<TextMesh>().text = look;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            info.GetComponentsInChildren<Transform>(true)[1].gameObject.SetActive(true);
            info.GetComponentsInChildren<Transform>(true)[1].gameObject.GetComponent<TextMesh>().text = name;
            info.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
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
