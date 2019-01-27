using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    enum Parents
    {
        Father,
        Mother
    }

    enum Events
    {
        ToiletLid,
        Necktie,
        LawnMower,
        AnsweringMachine,
        MuddyShoes,
        Laundry,
        Whiskey,
        Cigarettes,
        Letter
    }

    //    private Dictionary<Events, bool> toSay = new Dictionary<Events, bool>() {
    //        { Events.ToiletLid, true },
    //        { Events.LawnMower, true },
    //        { Events.MuddyShoes, false },
    //        { Events.Whiskey, true },
    //        { Events.Letter, true },
    //        { Events.Necktie, true },
    //        { Events.AnsweringMachine, false },
    //        { Events.Laundry, true },
    //        { Events.Cigarettes, true }
    //    };

    private List<Events> order = new List<Events> {
        Events.ToiletLid,
        Events.Necktie,
        Events.LawnMower,
        Events.AnsweringMachine,
        Events.MuddyShoes,
        Events.Laundry,
        Events.Whiskey,
        Events.Cigarettes,
        Events.Letter
    };

    public List<bool> toSay = new List<bool>
    {
        false,
        false,
        true,
        true,
        true,
        false,
        false,
        false,
        false
    };

    private Parents parent = Parents.Mother;
    private Dictionary<Parents, Dictionary<Events, string>> texts = new Dictionary<Parents, Dictionary<Events, string>>()
    {
        {
            Parents.Mother,
            new Dictionary<Events, string>()
            {
                { Events.ToiletLid, "The lid is left open?! Again?!" },
                { Events.LawnMower, "My Begonias are a mess thanks to your damn\nlawn mower! Couldn't you be more considerate?!" },
                { Events.MuddyShoes, "Ah! My floor! Dirty from the mud!\nWhy didn't you wipe your shoes clean?!" },
                { Events.Whiskey, "Oh, so now you're hiding bottles?!\nHave you fallen back into alcohol?!" },
                { Events.Letter, "Now you did it! You've cheated on me!\nAnd who's that woman?! Your lusty secretary?!" }
            }
        },
        {
            Parents.Father,
            new Dictionary<Events, string>()
            {
                { Events.Necktie, "Can't you iron my clothes properly?!\nThis tie is ruined!" },
                { Events.AnsweringMachine, "You cleared the answering machine?!\nWhat about the bills?!" },
                { Events.Laundry, "What is your problem with the laundry?!\nIs it so hard not to mingle white and color? This shirt is pink!" },
                { Events.Cigarettes, "What do we have here? Isn't that your favorite vice?\nThe one you were supposed to have stopped!" }
            }
        }
    };

    private bool started = true;
    private GameObject timmy;
    private float timer;
    static private float duration = 3;
    private KeyValuePair<Events, bool> temp;

    // Start is called before the first frame update
    void Start()
    {
        timmy = this.transform.Find("Child").gameObject;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = duration;
                Debug.Log(toSay.Count);
                while (toSay.Count > 0 && !toSay[0])
                {
                    toSay.RemoveAt(0);
                    order.RemoveAt(0);
                    SwitchParent();
                }
                if (toSay.Count <= 0)
                    return;
                Debug.Log(toSay.Count);
                DisplayArguement(order[0]);
                toSay[0] = false;
            }
        }
    }

    void SwitchParent()
    {
        if (parent == Parents.Mother)
            parent = Parents.Father;
        else
            parent = Parents.Mother;
    }

    void WriteThings(string str)
    {
        GameObject tmp;

        tmp = this.transform.Find("Info").gameObject;
        Debug.Log(tmp);
        tmp.GetComponent<MeshRenderer>().sortingOrder = 6;
        tmp.GetComponent<TextMesh>().text = str;
    }

    void DisplayArguement(Events say)
    {
        Quaternion rotation = timmy.transform.rotation;
        if (parent == Parents.Mother)
            timmy.transform.rotation = new Quaternion(rotation.x, 180, rotation.z, rotation.w);
        else
            timmy.transform.rotation = new Quaternion(rotation.x, 0, rotation.z, rotation.w);
        if (texts[parent].ContainsKey(say))
            WriteThings(texts[parent][say]);
    }
}
