using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putis : MonoBehaviour
{
    BoxCollider2D bx;
    public GameObject inventory;
   
    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("cravate") == null)
            bx.enabled = true;
        else
            bx.enabled = false;
    }

    public void end()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_cravate_crame(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }
    }
}
