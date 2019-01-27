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
        timer = Time.time + 0.1f;
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
            HandleThings();
            
        }
    }

    void HandleThings()
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
        if (obj.GetComponent<Item>().actions[count] == "start")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "jerrycan")
                {
                    obj.GetComponent<StartEngine>().enabled = true;
                    player.GetComponent<PlayerMovement>().inventory.Remove(item);
                    gameObject.SetActive(false);
                    return;
                }
            }
            WriteThings("I need some Gas");
        }
        if (obj.GetComponent<Item>().actions[count] == "move")
        {
            Toillet tmp;
            if ((tmp = obj.GetComponent<Toillet>()) != null)
            {
                tmp.Switch();
                gameObject.SetActive(false);
            }
        }
        if (obj.GetComponent<Item>().actions[count] == "dirty")
        {
            Shoe tmp;
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {

                if (item.name == "shoe" && (tmp = item.GetComponent<Shoe>()) != null)
                {
                    if (obj.name == "dirt")
                    {
                        tmp.dirty = true;
                        WriteThings("Now the shoes are dirty !");
                        gameObject.SetActive(false);
                        return;
                    }
                    else if (tmp.dirty == true)
                    {
                        obj.GetComponent<Floor>().Activate();
                        WriteThings("Dad made such a mess !");
                        gameObject.SetActive(false);
                        return;
                    }
                    else
                    {
                        WriteThings("the shoes are too clean they will not\n leave a mark");
                    }
                }
            }
            if (obj.name == "dirt")
            {
                WriteThings("I have nothing to make a mess with");
            }

        }
    }

    void WriteThings(string str)
    {
        GameObject tmp;

        tmp = GameObject.Find("Info");
        tmp.transform.position = new Vector3(Camera.main.transform.position.x - 3, Camera.main.transform.position.y + 2.5f, 0);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<InfoManager>().timer = Time.time + 3f;
        tmp.GetComponent<TextMesh>().text = str;
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
