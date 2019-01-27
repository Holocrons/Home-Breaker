﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public List<string> actions;
    public string look;

    // Start is called before the first frame update
    void Start()
    {
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
}
