using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public List<GameObject> step;

    public void Activate()
    {
        foreach (GameObject go in step)
        {
            go.SetActive(true);
        }
    }
}
