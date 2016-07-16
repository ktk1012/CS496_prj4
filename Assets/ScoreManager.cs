using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public static int score = 0;
    private Text scoretext;

    // Use this for initialization
    void Start () {
        scoretext = GetComponent<Text>();
    }

    void Update()
    {
        scoretext.text = "Score " + score.ToString();
    }
}
