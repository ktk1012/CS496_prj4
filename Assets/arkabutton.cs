using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class arkabutton : MonoBehaviour { 
    public void goarka()
    {
        selectgame.type = 2;
        SceneManager.LoadScene("arkanoid_game");
    }
}

