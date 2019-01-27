using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{

    private TextMesh tm;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tm.text != "" && timer <= Time.time)
            tm.text = ""; 
    }
}
