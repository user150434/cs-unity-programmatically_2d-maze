using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject obj;

    public Player(GameObject obj)
    {
        this.obj = obj;
    }

    void Start()
    {
    }

    bool CanMoveTo(Vector3 newPos, Tile[][] path)
    {
        for (int i = 0; i < path.Length; i++)
        {
            for (int i2 = 0; i2 < path[i].Length; i2++)
            {
                Tile currentTile = path[i][i2];
                if (currentTile.isTower && currentTile.obj.transform.position == newPos)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Move(Vector3 newPos, Tile[][] path)
    {
        Debug.Log("======move");
        if (CanMoveTo(newPos, path))
        {
            Debug.Log("======CanMoveTo");
            obj.transform.position = newPos;
        }
    }

    public void DoMove(Tile[][] path)
    {
        Vector3 newPos = obj.transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos += new Vector3(0, 0, 2);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos += new Vector3(0, 0, -2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos += new Vector3(-2, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos += new Vector3(2, 0, 0);
        }

        Move(newPos, path);
    }
}