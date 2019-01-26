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
}
