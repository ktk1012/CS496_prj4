using UnityEngine;
using System.Collections;

public class holdbutton : MonoBehaviour {
    public static bool hold = false;
    // Use this for initialization
    public void holdcall()
    {
        hold = true;
        Debug.Log("hold");
    }
}
