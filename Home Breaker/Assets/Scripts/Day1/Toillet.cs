using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toillet : MonoBehaviour
{
    public Sprite[] spr;
    private int i = 1;
    private SpriteRenderer sp;
    private Item it;

    private void Start()
    {
        it = GetComponent<Item>();
        sp = GetComponent<SpriteRenderer>();
    }

    public void Switch()
    {
        sp.sprite = spr[i];
        if (i == 1)
        {
            i = 0;
            it.look = "the seat is up";
        }
        else
        {
            i = 1;
            it.look = "the seat is down";
        }
    }
}
