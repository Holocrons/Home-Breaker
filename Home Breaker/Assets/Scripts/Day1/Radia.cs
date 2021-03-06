﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radia : MonoBehaviour
{
    public GameObject inventory;
    public GameObject prefabs;

    public void heater()
    {
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_cle_molette(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }
        t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_cravate(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }
        GameObject go = Instantiate(prefabs);
        GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Add(go);
        go.transform.parent = GameObject.Find("Inventory").transform;
        go.transform.localScale = new Vector2(2, 2);
        go.GetComponent<SpriteRenderer>().sortingOrder = 5;

    }
}
