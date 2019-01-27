using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radia : MonoBehaviour
{
    public GameObject inventory;

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

    }
}
