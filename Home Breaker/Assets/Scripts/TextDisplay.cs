using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;

public class TextDisplay : MonoBehaviour
{

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        DisplayText("Zuccini");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayText(string str)
    {
      /*  GameObject tmp;

        tmp = Instantiate(prefabs);
        tmp.GetComponent<TextMesh>().text = str;*/
    }
}
