using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMenu : MonoBehaviour
{
    public GameObject obj = null;
    private TextMesh[] tm;
    private int nb = 0;
    private int count = 0;
    public GameObject arrow;
    public float timer;
    public GameObject player;
    private Vector2 basPos;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer[] mr;
        tm = GetComponentsInChildren<TextMesh>();
        mr = GetComponentsInChildren<MeshRenderer>();
        mr[0].sortingOrder = 4;
        mr[1].sortingOrder = 4;
        UpdateData();
        basPos.x = transform.position.x - 0.75f;
        basPos.y = transform.position.y - 0.25f;
        arrow.transform.position = basPos;
    }


    // Update is called once per frame
    void Update()
    {
        if (obj.name != tm[0].text)
        {
            UpdateData();
        }
        if (Input.GetKeyDown(KeyCode.S) && count < nb - 1)
        {
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y - 0.5f);
            count++;
        }
        if (Input.GetKeyDown(KeyCode.Z) && count > 0)
        {
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y + 0.5f);
            count--;
        }
        if (Input.GetKeyDown(KeyCode.E) && timer <= Time.time)
        {
            if (obj.GetComponent<Item>().actions[count] == "take")
            {
                player.GetComponent<PlayerMovement>().inventory.Add(obj);
                obj.SetActive(false);
                gameObject.SetActive(false);
                obj.transform.parent = GameObject.Find("Inventory").transform;
                timer = Time.time + 0.1f;
            }
            if (obj.GetComponent<Item>().actions[count] == "look")
            {
                obj.GetComponent<Item>().Look();
                timer = Time.time + 0.1f;
            }
        }
    }

    void UpdateData()
    {
        basPos.x = transform.position.x - 0.75f;
        basPos.y = transform.position.y - 0.25f;
        tm[0].text = obj.name;
        tm[1].text = "";
        nb = 0;
        arrow.transform.position = new Vector2(arrow.transform.position.x, basPos.y);
        count = 0;
        foreach (string str in obj.GetComponent<Item>().actions)
        {
            tm[1].text += str + "\n";
            nb++;
        }
    }
}
