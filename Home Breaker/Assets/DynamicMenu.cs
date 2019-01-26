using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMenu : MonoBehaviour
{
    public GameObject obj = null;
    private TextMesh[] tm;
    private int nb = 0;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponentsInChildren<TextMesh>();
        UpdateData();
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.name != tm[0].text)
        {
            UpdateData();
        }
    }

    void UpdateData()
    {
        tm[0].text = obj.name;
        tm[1].text = "";
        foreach (string str in obj.GetComponent<Item>().actions)
        {
            tm[1].text += str + "\n";
            nb++;
        }
    }
}
