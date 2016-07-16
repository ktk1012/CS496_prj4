using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class next : MonoBehaviour
{
    public GameObject[] act;
    public GameObject[] inact;
    public GameObject[] hd;
    public GameObject vaus;
    public static int nextblk;
    public static int curblk;
    public static int holdblk;


    // Use this for initialization
    public void active(int i)
    {
        Instantiate(act[i], transform.position, Quaternion.identity);
    }

    public void hold(int i)
    {
        Instantiate(hd[i], transform.position, Quaternion.identity);
    }

    public int inactive()
    {
        int i = Random.Range(0, inact.Length);
        Instantiate(inact[i], transform.position, Quaternion.identity);
        return i;
    }

    void Start()
    {
        int i = inactive();
        int j = inactive();
        nextblk = j; 
        active(i);
        curblk = i;
    }
}