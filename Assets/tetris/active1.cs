using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class active1 : MonoBehaviour
{
    private int tmp;
    float lastFall = 0;
    private bool fst = true;
    private static bool holdfst = true;
    public static bool call = true;
    public static bool del = false;

    void Start()
    {
        if (fst)
        {
            transform.position = new Vector3(7, 12, 0);
            fst = false;
        }

        if (!isValidGridPos())
            Debug.Log("GAME OVER");
    }

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))  // left
        {
            lastFall = Time.time;
            transform.position += new Vector3(-1, 0, 0);
            leftbutton.left = false;

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.E)) // rotate 
        {
            transform.Rotate(0, 0, -90);
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        else if (Input.GetKeyDown(KeyCode.F)) // right
        {
            transform.position += new Vector3(1, 0, 0);
            rightbutton.right = false;

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.D) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
				Debug.Log ("Invalid");
                transform.position += new Vector3(0, 1, 0);

                Grid.deleteFullRows();

                call = true;


                // activate
                next.curblk = next.nextblk;
                FindObjectOfType<next>().active(next.curblk);
                // create the next 
                next.nextblk = FindObjectOfType<next>().inactive();


				enabled = false;
            }
			lastFall = Time.time;
        }
    }
}
    




   
       
