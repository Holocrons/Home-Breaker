using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    public GameObject inventory;

    public void HideIt()
    {

        GameObject tmp;

        tmp = GameObject.Find("Info");
        tmp.transform.position = new Vector3(Camera.main.transform.position.x - 3, Camera.main.transform.position.y + 2.5f, 0);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<InfoManager>().timer = Time.time + 3f;
        tmp.GetComponent<TextMesh>().text = "alcoholism + family = BOOM";
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_whiskey(Clone)")   
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }

    }
}

