﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grid : MonoBehaviour
{
    // The Grid itself
    public static int w = 15;
    public static int h = 16;
    public static Transform[,] grid = new Transform[w, h];

    /* round the vector */
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    /* border condition */
    /* groups cannot move upwards, so it doesn't check if pos.y < h */
    public static bool insideBorder(Vector2 pos)
    {
		return (((int)pos.x > 0 && (int)pos.x < w && (int)pos.y > 0));
    }

    /* if the player fills every entry in a row, the row should be deleted */
    public static void deleteRow(int y)
    {
		for (int x = 0; x < w; ++x)
        {
            if (grid[x, y].gameObject != null)
                Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    /* whenever a row was deleted, the above rows should fall towards
     * the bottom by one unit */
    public static void decreaseRow(int y)
    {
		for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {   /* move one towards bottom */
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                /* update block position */
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
		for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    public static void deleteFullRows()
    {
		Debug.Log ("DeleteFull Row");
        for (int y = 2; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                y = y - 1;
            }
        }
    }
}
