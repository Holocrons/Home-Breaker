using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject inventory;
    public List<GameObject> step;

    public void Activate()
    {
        foreach (GameObject go in step)
        {
            go.SetActive(true);
        }
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_chassure(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }

    }
}
