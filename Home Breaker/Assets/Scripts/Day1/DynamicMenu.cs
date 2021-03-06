﻿using System.Collections;
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
    private bool radia = false;
    private bool write = false;
    private bool parf = false;

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
        basPos.y = transform.position.y - 0.15f;
        arrow.transform.position = basPos;
        timer = Time.time + 0.1f;
    }


    private void OnEnable()
    {
        GameObject.Find("objinfo").GetComponentsInChildren<Transform>(true)[1].gameObject.SetActive(false);
        MeshRenderer[] mr;
        tm = GetComponentsInChildren<TextMesh>();
        mr = GetComponentsInChildren<MeshRenderer>();
        mr[0].sortingOrder = 4;
        mr[1].sortingOrder = 4;
        UpdateData();
        basPos.x = transform.position.x - 0.75f;
        basPos.y = transform.position.y - 0.15f;
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
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y - 0.25f);
            count++;
        }
        if (Input.GetKeyDown(KeyCode.Z) && count > 0)
        {
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y + 0.25f);
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
            Camera.main.GetComponent<CameraManager>().PlayClip(0, 1f);
            obj.SetActive(false);
            gameObject.SetActive(false);
            GameObject tmp = Instantiate(obj.GetComponent<Item>().miniItem);
            player.GetComponent<PlayerMovement>().inventory.Add(tmp);
            tmp.transform.parent = GameObject.Find("Inventory").transform;
            tmp.transform.localScale = new Vector2(2, 2);
            tmp.GetComponent<SpriteRenderer>().sortingOrder = 5;
            timer = Time.time + 0.1f;
        }
        if (obj.GetComponent<Item>().actions[count] == "look" && timer <= Time.time)
        {
            obj.GetComponent<Item>().Look();
            timer = Time.time + 0.1f;
        }
        if (obj.GetComponent<Item>().actions[count] == "start")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name.IndexOf("jerrycan") != -1)
                {
                    player.GetComponent<PlayerMovement>().b[2] = true;
                    obj.GetComponent<StartEngine>().enabled = true;
                    player.GetComponent<PlayerMovement>().inventory.Remove(item);
                    gameObject.SetActive(false);
                    return;
                }
            }
            WriteThings("I need some gas");
            Camera.main.GetComponent<CameraManager>().PlayClip(2, 10f);
        }
        if (obj.GetComponent<Item>().actions[count] == "move")
        {
            Toillet tmp;
            if ((tmp = obj.GetComponent<Toillet>()) != null)
            {
                tmp.Switch();
                player.GetComponent<PlayerMovement>().b[0] = true;
                gameObject.SetActive(false);
            }
        }
        if (obj.GetComponent<Item>().actions[count] == "dirty")
        {
            Shoe tmp;
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_chassure(Clone)")
                {
                    item.AddComponent<Shoe>();
                    tmp = item.GetComponent<Shoe>();
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
                        player.GetComponent<PlayerMovement>().b[4] = true;
                        gameObject.SetActive(false);
                        return;
                    }
                    else
                    {
                        WriteThings("The shoes are too clean they wouldn't\nleave a mark");
                    }
                }
            }
            if (obj.name == "dirt")
            {
                WriteThings("I have nothing to make a mess with.");
            } 
        }
        if (obj.GetComponent<Item>().actions[count] == "hide")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_whiskey(Clone)" && obj.name == "Closet")
                {
                    obj.GetComponent<Closet>().HideIt();
                    player.GetComponent<PlayerMovement>().b[6] = true;
                    return;
                }
                else if (item.name == "v_paquet_clopes(Clone)" && obj.name == "purse")
                {
                    WriteThings("Old demons strike back!");
                    player.GetComponent<PlayerMovement>().b[7] = true;
                    obj.GetComponent<Purse>().pu();
                    return;
                }
            }
            WriteThings("I don't have anything to hide in there.");
        }
        if (obj.GetComponent<Item>().actions[count] == "repair")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_cle_molette(Clone)")
                {
                    radia = true;
                    WriteThings("This thing could burn anything now !"); 
                    return;
                }
            }
            if (radia == false)
                WriteThings("I need tools to repair it !");
            else
                WriteThings("It works fine.");
        }
        if (obj.GetComponent<Item>().actions[count] == "burn")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_cravate(Clone)" && radia == true)
                {
                    WriteThings("RIP little tie ...");
                    gameObject.SetActive(false);
                    player.GetComponent<PlayerMovement>().b[1] = true;
                    obj.GetComponent<Radia>().heater();
                    return;
                }
                else if (item.name == "v_cravate(Clone)" && radia == false)
                {
                    WriteThings("The heater is cold");
                    return ;
                }
            }
            WriteThings("I have nothing to burn");
        }
        if (obj.GetComponent<Item>().actions[count] == "erase")
        {
            player.GetComponent<PlayerMovement>().b[3] = true;
            WriteThings("Yeah those 'unpaid bills' can wait");
        }
        if (obj.GetComponent<Item>().actions[count] == "wash")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_chemise(Clone)")
                {
                    WriteThings("From white to pink !");
                    player.GetComponent<PlayerMovement>().b[5] = true;
                    obj.GetComponent<WasingMachine>().Wash();
                    gameObject.SetActive(false);
                    return;
                }
            }
            WriteThings("I have nothing to wash for now");
        }
        if (obj.GetComponent<Item>().actions[count] == "write")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_encrier(Clone)")
                {
                    write = true;
                }
                else if (item.name == "v_parfum(Clone)")
                {
                    parf = true;
                }
            }
            if (write == false)
            {
                WriteThings("I need something fancier than a pen to\nwrite this letter");
            }
            else if (parf == false)
            {
                WriteThings("It needs a feminin touch to make it real");
            }
            else
            {
                player.GetComponent<PlayerMovement>().b[8] = true;
                WriteThings("..... And done ! I can leave it here");
                obj.GetComponent<Letter>().Let();
                gameObject.SetActive(false);
            }
        }
        if (obj.GetComponent<Item>().actions[count] == "put it")
        {
            foreach (GameObject item in player.GetComponent<PlayerMovement>().inventory)
            {
                if (item.name == "v_cravate_crame(Clone)")
                {
                    obj.GetComponent<putis>().end();
                    return;
                }
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
        basPos.y = transform.position.y - 0.15f;
        if (obj == null)
            return;
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
