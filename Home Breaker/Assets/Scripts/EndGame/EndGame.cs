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
        true,
        true,
        true,
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
    private int finale = 0;

    // Start is called before the first frame update
    void Start()
    {
        timmy = this.transform.Find("Child").gameObject;
        timer = 0;
        GameObject.Find("Timer").SetActive(false);
        GameObject.Find("Inventory").SetActive(false);
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
                while (toSay.Count > 0 && !toSay[0])
                {
                    toSay.RemoveAt(0);
                    order.RemoveAt(0);
                    SwitchParent();
                }
                if (toSay.Count <= 0)
                {
                    DisplayEnd();
                    return;
                }
                finale++;
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

    void DisplayEnd()
    {
        bool win = false;
        if (finale >= 5)
            win = true;
        this.transform.Find("Child").gameObject.SetActive(false);
        this.transform.Find("Mother").gameObject.SetActive(false);
        this.transform.Find("Father").gameObject.SetActive(false);
        this.transform.Find("Info").gameObject.SetActive(false);
        if (win)
        {
            this.transform.Find("ending-won").gameObject.SetActive(true);
            this.transform.Find("Win").gameObject.SetActive(true);
            this.transform.Find("Win").gameObject.GetComponent<MeshRenderer>().sortingOrder = 5;
        }
        else
        {
            this.transform.Find("ending-loss").gameObject.SetActive(true);
            this.transform.Find("Loss").gameObject.SetActive(true);
            this.transform.Find("Loss").gameObject.GetComponent<MeshRenderer>().sortingOrder = 5;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
