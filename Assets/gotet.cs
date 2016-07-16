using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gotet : MonoBehaviour
{

    public void Gotet()
    {
        selectgame.type = 1;
        SceneManager.LoadScene("Tetris");
    }
}
