using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    private static int mLife;


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        mLife--;
    }

    public void SetmLife(int life)
    {
        mLife = life;
    }

    public int GetmLife()
    {
        return mLife;
    }

    void Update()
    {
        if (mLife == 0)
        {
            Destroy(gameObject);
            Vector3 v = transform.position;
            Grid.nullify(new Vector2 (Mathf.Round(v.x), Mathf.Round(v.y)));
        }

        if (Grid.getStronger)
        {
            SetmLife(3);
        }

        Grid.getStronger = false;
    }


}
