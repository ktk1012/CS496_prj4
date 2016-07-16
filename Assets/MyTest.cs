using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;
using System.Collections.Generic;
using System.Linq;

public class MyTest : MonoBehaviour
{
    [SerializeField] InputField inputfield;
    private static string username;
    [SerializeField] Text rank1;
    [SerializeField] Text rank2;
    [SerializeField] Text rank3;
    private int gameType = selectgame.type;

    private Dictionary<string, int> TetrisScoreList;
    private Dictionary<string, int> ArkanoidScoreList;
    private string[] TetrisScoreList_Ordered;
    private string[] ArkanoidScoreList_Ordered;

    public void Init()
    {
        string url = "https://project3-jisu0123.c9users.io/post";
        WWWHelper helper = WWWHelper.Instance;
        username = inputfield.text;
        helper.post(100, url, selectgame.type, username, 100);
        get();

    }
 

    void get()
    {
        string url = "https://project3-jisu0123.c9users.io/get1";
        WWWHelper helper = WWWHelper.Instance;
        helper.OnHttpRequest += OnHttpRequest;
        helper.get(100, url);
    }


    void OnHttpRequest(int id, WWW www)
    {
        TetrisScoreList = new Dictionary<string, int>();
        ArkanoidScoreList = new Dictionary<string, int>();
        if (www.error != null)
        {
            Debug.Log("[Error] " + www.error);
            return;
        }

        JsonData items = JsonMapper.ToObject(www.text);
        int count = items.Count;
        Debug.Log(count.ToString());

        for (int i = 0; i < count; i++)
        {
            JsonData item = items[i];
            int type = Int32.Parse(item["type"].ToString());
            string name = item["name"].ToString();
            int score = Int32.Parse(item["score"].ToString());
            if (type == 1)
            {
                TetrisScoreList[name] = new int();
                TetrisScoreList[name] = score;
            }
            else if (type == 2)
            {
                ArkanoidScoreList[name] = new int();
                ArkanoidScoreList[name] = score;
            }
        }

        if (gameType == 1)
        {
            TetrisScoreList_Ordered = GetTetrisNames();
            string tetris_one = TetrisScoreList_Ordered[0];
            Debug.Log(tetris_one);
            int tetris_one_score = TetrisScoreList[tetris_one];
            string tetris_two = TetrisScoreList_Ordered[1];
            int tetris_two_score = TetrisScoreList[tetris_two];
            string tetris_three = TetrisScoreList_Ordered[2];
            int tetris_three_score = TetrisScoreList[tetris_three];
            rank1.text = String.Format("1 {0} {1}", tetris_one, tetris_one_score.ToString());
            rank2.text = String.Format("2 {0} {1}", tetris_two, tetris_two_score.ToString());
            rank3.text = String.Format("3 {0} {1}", tetris_three, tetris_three_score.ToString());
        }
        else if (gameType == 2)
        {
            Debug.Log(gameType.ToString());
            ArkanoidScoreList_Ordered = GetArkanoidNames();
            string arkanoid_one = ArkanoidScoreList_Ordered[0];
            Debug.Log(arkanoid_one);
            int arkanoid_one_score = ArkanoidScoreList[arkanoid_one];
            string arkanoid_two = ArkanoidScoreList_Ordered[1];
            Debug.Log(arkanoid_two);
            int arkanoid_two_score = ArkanoidScoreList[arkanoid_two];
            string arkanoid_three = ArkanoidScoreList_Ordered[2];
            int arkanoid_three_score = ArkanoidScoreList[arkanoid_three];
            rank1.text = String.Format("1 {0} {1}", arkanoid_one, arkanoid_one_score.ToString());
            rank2.text = String.Format("2 {0} {1}", arkanoid_two, arkanoid_two_score.ToString());
            rank3.text = String.Format("3 {0} {1}", arkanoid_three, arkanoid_three_score.ToString());
        }
    }

    int GetArkanoidScore(string username)
    {
        //Init_Arkanoid();
        if (ArkanoidScoreList.ContainsKey(username) == false)
        {
            return 0;
        }
        return ArkanoidScoreList[username];
    }

    int GetTetrisScore(string username)
    {
        //Init_Arkanoid();
        if (TetrisScoreList.ContainsKey(username) == false)
        {
            return 0;
        }
        return TetrisScoreList[username];
    }

    string[] GetArkanoidNames()
    {
        //Init_Arkanoid();
        return ArkanoidScoreList.Keys.OrderByDescending(n => GetArkanoidScore(n)).ToArray();
    }

    string[] GetTetrisNames()
    {
        //Init_Tetris();
        return TetrisScoreList.Keys.OrderByDescending(n => GetTetrisScore(n)).ToArray();
    }


}