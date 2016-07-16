using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] Text life;
    [SerializeField] GameObject racket;
    [SerializeField] Text levelText;

    Vector3 originalPosition = new Vector3(7, -13, 0);
    Vector3 racketOriginalPosition = new Vector3(0, -14, 0);

    private float speed = 25f;
    private int lifeCount = 3;
    
	// Use this for initialization
	void Start () {

        racket.transform.position = racketOriginalPosition;
        transform.position = originalPosition;

        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        //life.text = string.Format("Life {0}", lifeCount);
	}

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.y <= -14)
        {
            lifeCount--;
            if (lifeCount == 0)
                Debug.Log("Game Over");
            Restart();
        } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "vaus")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    void Restart()
    {
        transform.position = originalPosition;
        racket.transform.position = racketOriginalPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void Reset()
    {
        transform.position = originalPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        racket.transform.position = racketOriginalPosition;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void SetLifeText()
    {
        life.text = string.Format("Life {0}", lifeCount);
    }
}
