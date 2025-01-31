using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public GameObject obj;
    public bool isTower;

    public Tile(GameObject obj, bool isTower)
    {
        this.obj = obj;
        this.isTower = isTower;
    }
}