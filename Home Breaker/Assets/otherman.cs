using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherman : MonoBehaviour
{
    public float speed = 5;
    public int x = 2;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x = 2;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            x = -2;
        }
        else
        {
            x = 0;
        }
        if (x < 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(2, 2);
        if (x > 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-2, 2);
        anim.SetInteger("running", x);
        transform.Translate(new Vector2(x, 0) * Time.deltaTime * speed);
    }
}

