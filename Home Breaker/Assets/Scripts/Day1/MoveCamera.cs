using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float limit;
    public bool right; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && collision.GetComponent<PlayerMovement>().currentsScene == 3)
        {
            if (right == true && transform.parent.gameObject.transform.position.x >= limit)
                return;
            if (right == false && transform.parent.gameObject.transform.position.x <= limit)
                return;
            transform.parent.gameObject.transform.Translate(new Vector2(collision.GetComponent<PlayerMovement>().x, 0) * Time.deltaTime * 3.7f);
        }
    }
}
