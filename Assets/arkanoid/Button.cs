using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public void OnClick()
    {
        //Application.LoadLevel("Scene");
        SceneManager.LoadScene("0");
    }
}
