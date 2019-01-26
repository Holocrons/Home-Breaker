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

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            x = -1;
        }
        else
        {
            x = 0;
        }
        transform.Translate(new Vector2(x, 0) * Time.deltaTime * speed);
    }
}
