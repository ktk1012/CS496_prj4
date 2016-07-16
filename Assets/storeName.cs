using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class storeName : MonoBehaviour {

    [SerializeField] InputField inputfield;
    public static string usrname;

    public void CopyText()
    {
        usrname = inputfield.text;
    }

}
