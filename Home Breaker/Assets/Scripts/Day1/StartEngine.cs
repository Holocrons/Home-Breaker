﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    public GameObject inventory;
    public Sprite[] spr;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;

        tmp = GameObject.Find("Info");
        tmp.transform.position = new Vector3(Camera.main.transform.position.x - 3, Camera.main.transform.position.y + 2.5f, 0);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<InfoManager>().timer = Time.time + 3f;
        tmp.GetComponent<TextMesh>().text = "Good bye stupid flowers";
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_jerrycan(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }
        Camera.main.GetComponent<CameraManager>().PlayClip(3, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 27)
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flowers")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = spr[i];
            collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y - 0.2f);
            if (i == 0)
                i = 1;
            else
                i = 0;
        }
    }
}
