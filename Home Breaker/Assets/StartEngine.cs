using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
