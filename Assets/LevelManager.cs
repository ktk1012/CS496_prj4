using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public static int level;
    private Text lvtext;
    public static double time;

    // Use this for initialization
    void Start () {
        level = 1;
        time = 1.6;
        lvtext = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        lvtext.text = "Lv " + level.ToString();
    }
}
