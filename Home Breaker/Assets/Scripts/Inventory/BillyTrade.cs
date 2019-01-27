using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillyTrade : MonoBehaviour
{
    private GameObject wall;
    static private float scale = 1;
    static private float objectSize = 32 * scale;
    static private float shift = objectSize;
    static private int maxTrade = 4;
    private int tradePos = 0;
    static private float[] positions = { -4, -1.3f, 1.6f, 4.5f};
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        wall = this.gameObject;
        SetChildren();
    }

    // Update is called once per frame
    void Update()
    {
        ColorChildren();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveSelector(KeyCode.LeftArrow);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveSelector(KeyCode.RightArrow);
        if (Input.GetKeyDown(KeyCode.E))
            TradeObjects();
        SetSelector();
    }

    void TradeObjects()
    {
        Transform child = wall.transform.GetChild(tradePos);
        Transform item = child.transform.GetChild(0);
        GameObject inventory = GameObject.Find("Inventory");
        Transform test = inventory.transform.Find(item.name);
        if (test)
        {
            Destroy(test.gameObject);
            item.transform.SetParent(wall.transform);
            item.SetSiblingIndex(tradePos);
            item.gameObject.SetActive(false);
            child.SetParent(inventory.transform);
        }
    }

    void MoveSelector(KeyCode key)
    {
        if (key == KeyCode.RightArrow)
            tradePos++;
        else
            tradePos--;
        if (tradePos < 0)
            tradePos = maxTrade - 1;
        else if (tradePos >= maxTrade)
            tradePos = 0;
        SetSelector();
    }

    void SetSelector()
    {
        //var pos = cam.WorldToScreenPoint(wall.transform.position);
        //wall.transform.Find("Selector").position = cam.ScreenToWorldPoint(new Vector3((pos.x + tradePos * (objectSize + 2 * shift)) / 1.5f - 100, pos.y, pos.z));
        wall.transform.Find("Selector").localPosition = new Vector3(positions[tradePos], 0, 0);
    }

    private void SetChildren()
    {
        int i = 0;
        var pos = cam.WorldToScreenPoint(wall.transform.position);
        foreach (Transform child in transform)
        {
            //SetPosition(child, i, pos);
            i++;
        }
    }

    void SetPosition(Transform child, int i, Vector3 pos)
    {
        if (child.name == "Selector")
        {
            SetSelector();
            i -= 1;
            return;
        }
        else if (!child.gameObject.activeSelf)
            return;
        var cpos = child.position;
        Vector3 newPos = cam.ScreenToWorldPoint(new Vector3((pos.x + i * (objectSize + 2 * shift)) / 1.5f, pos.y + objectSize, pos.z));
        child.transform.position = newPos;
        cpos = cam.WorldToScreenPoint(child.transform.position);
        var subChild = child.GetChild(0);
        newPos = cam.ScreenToWorldPoint(new Vector3(cpos.x, pos.y - objectSize, pos.z));
        subChild.position = newPos;
    }

    void ColorChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Selector" || !child.gameObject.activeSelf)
                return;
            var subChild = child.GetChild(0);
            var inventory = GameObject.Find("Inventory");
            var items = inventory.transform.Find(subChild.name);
            float color = 0.5f;
            if (items)
            {
                color = 1f;
            }
            subChild.GetComponent<SpriteRenderer>().color = new Color(color, color, color);
        }
    }
}
