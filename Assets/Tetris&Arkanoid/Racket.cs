using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {


    private float speed = 150;

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);

            // Not inside Border?
            if (!Grid.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

    void Update()
    {
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
           GetComponent<Rigidbody2D>().velocity = Vector2.right *speed;
           
        }

       GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
}
