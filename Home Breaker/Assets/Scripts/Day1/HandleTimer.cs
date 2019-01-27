using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTimer : MonoBehaviour
{
    private Text uiText;
    private float mainTimer;
    public GameObject prefabs;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Start()
    {
        timer = 240;//420;
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
            GetComponent<TextMesh> ().text = "0.00";
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
        GameObject.Find("Timmy").GetComponent<PlayerMovement>().currentsScene = 12;

        prefabs.GetComponent<EndGame>().toSay = GameObject.Find("Timmy").GetComponent<PlayerMovement>().b;
        prefabs.SetActive(true);

    }
}
