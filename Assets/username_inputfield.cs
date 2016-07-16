using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class username_inputfield : MonoBehaviour {
    public InputField inputfield;
    public static Text username;

    // Use this for initialization
    public string stringToEdit = "Hello World";
    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
    }

    // Update is called once per frame
    void Update() 
    {

    }
}
