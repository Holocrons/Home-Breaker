using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTimer : MonoBehaviour
{
    private Text uiText;
    private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Start()
    {
        timer = 300;
        GetComponent<MeshRenderer>().sortingOrder = 4;
    }

    private void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            GetComponent<TextMesh>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(timer / 60), timer % 60);
        }
        else if (timer <= 0.0F && !doOnce)
        {
            canCount = false;
            doOnce = true;
            GetComponent<Text> ().text = "0.00";
            timer = 0.0F;
            ChangeScene();
        }
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void ChangeScene()
    {
        
    }
}
