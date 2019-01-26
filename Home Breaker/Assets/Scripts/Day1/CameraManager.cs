using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> cameraPositions;
    public GameObject player;
    private PlayerMovement pm;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i != pm.currentsScene)
        {
            i = pm.currentsScene;
            transform.position = new Vector3(cameraPositions[i].transform.position.x, cameraPositions[i].transform.position.y, -10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerMovement>().currentsScene == 3)
        {
            transform.Translate(new Vector2(collision.GetComponent<PlayerMovement>().x, 0) * Time.deltaTime * 7.5f);
        }
    }
}
