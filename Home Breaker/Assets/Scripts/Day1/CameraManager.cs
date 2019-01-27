using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> cameraPositions;
    public GameObject player;
    private PlayerMovement pm;
    private int i = 0;
    public AudioClip[] ac;
    private AudioSource aso;

    // Start is called before the first frame update
    void Start()
    {
        aso = GetComponent<AudioSource>();
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i != pm.currentsScene)
        {
            i = pm.currentsScene;
            transform.position = new Vector3(cameraPositions[i].transform.position.x, cameraPositions[i].transform.position.y, -10);
            if (i == 3)
              transform.position = new Vector3(player.transform.position.x, cameraPositions[i].transform.position.y, -10);
        }
    }

    public void PlayClip(int i, float vol)
    {
        aso.PlayOneShot(ac[i], vol);
    }
}
