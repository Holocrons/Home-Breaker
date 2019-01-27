using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    public GameObject inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;

        tmp = GameObject.Find("Info");
        tmp.transform.position = new Vector3(Camera.main.transform.position.x - 3, Camera.main.transform.position.y + 2.5f, 0);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<InfoManager>().timer = Time.time + 3f;
        tmp.GetComponent<TextMesh>().text = "Good bye stupid flowers";
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_jerrycan(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 27)
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flowers")
            Destroy(collision.gameObject);
    }
}
