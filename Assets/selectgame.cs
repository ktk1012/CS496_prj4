using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class selectgame : MonoBehaviour {
    public static int type;
    private Text selecttext;
    private static float lasttime;
    private static bool active = true;
    // Use this for initialization
    void Start () {
        selecttext = GetComponent<Text>();
        lasttime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lasttime > 0.2)
        {
            lasttime = Time.time;
            active = (active) ? false : true;
        }

        if (active)
        {
            selecttext.text = "Select Game";
        }
        else
        {
            selecttext.text = "";
        }
    }
}
