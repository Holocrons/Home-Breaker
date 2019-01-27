using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasingMachine : MonoBehaviour
{

    public Sprite spr;
    private SpriteRenderer sr;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wash()
    {
        sr.sprite = spr;
        Transform[] t = inventory.GetComponentsInChildren<Transform>(true);
        foreach (Transform nt in t)
        {
            if (nt.gameObject.name == "v_chemise(Clone)")
            {
                GameObject.Find("Timmy").GetComponent<PlayerMovement>().inventory.Remove(nt.gameObject);
                Destroy(nt.gameObject);
            }
        }
    }
}
