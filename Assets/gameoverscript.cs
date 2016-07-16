using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameoverscript : MonoBehaviour {
 
    private Text overtext;
    private static float lasttime;
    private static bool active = true;
    // Use this for initialization
    void Start()
    {
        overtext = GetComponent<Text>();
        lasttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasttime > 0.2)
        {
            lasttime = Time.time;
            active = (active) ? false : true;
        }

        if (active)
        {
            overtext.text = "Game Over";
        }
        else
        {
            overtext.text = "";
        }
    }
}

