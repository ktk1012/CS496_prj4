using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tetrisbutton : MonoBehaviour {
	// Use this for initialization
	public void loadgame()
    {
        if (selectgame.type == 1)
            SceneManager.LoadScene("Tetris");
        else
            SceneManager.LoadScene("arkanoid_game");
    }
}
