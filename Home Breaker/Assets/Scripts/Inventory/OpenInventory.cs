using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private GameObject cube;
    private bool state = false;
    static private int scale = 2;
    static private int objectSize = 32 * scale;
    static private int shift = 10;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = cam.WorldToScreenPoint(cube.transform.position);
        cube.transform.position = cam.ScreenToWorldPoint(new Vector3(objectSize / 2 + shift, objectSize / 2 + shift, pos.z));
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchVisibility();
        }
    }

    void SwitchVisibility()
    {
        state = !state;
        int i = 1;
        Vector3 pos = cam.WorldToScreenPoint(this.transform.position);
        foreach (Transform child in transform)
        {
            SetPosition(child, i, pos);
            child.gameObject.SetActive(state);
            i++;
        }
        Debug.Log("push");
    }

    void SetPosition(Transform child, int i, Vector3 pos)
    {
        var cpos = child.position;
        Debug.Log(pos);
        Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(pos.x + i * (objectSize + 2 * shift), pos.y, pos.z));
        child.transform.position = newPos;
        Debug.Log("done");
    }
}
