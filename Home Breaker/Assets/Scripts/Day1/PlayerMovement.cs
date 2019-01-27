using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public int x = 0;
    public int currentsScene = 0;
    public float timer;
    public bool canTp = true;
    public List<GameObject> inventory;
    public GameObject menuItem;
    private Animator anim;
    public List<bool> b = new List<bool>() {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false
    };

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 0.1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<CameraManager>() && Camera.main.GetComponent<CameraManager>().i == 11)
            return;
        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
            menuItem.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            x = -1;
            menuItem.SetActive(false);
        }
        else
        {
            x = 0;
        }
        if (x < 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(1, 1);
        if (x > 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-1, 1);
        anim.SetInteger("running", x);
        transform.Translate(new Vector2(x, 0) * Time.deltaTime * speed);
        foreach (var elem in b)
            if (elem == false)
                return;
        var obj = GameObject.Find("Timer");
        if (obj)
            obj.GetComponent<HandleTimer>().ChangeScene();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "item" && Input.GetKeyDown(KeyCode.E))
        {
            menuItem.SetActive(true);
            menuItem.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 2, -5);
            menuItem.GetComponent<DynamicMenu>().obj = collision.gameObject;
            if (collision.name == "wine")
                menuItem.transform.position = new Vector3(collision.transform.position.x - 1, collision.transform.position.y, -5);
        }
    }
}
