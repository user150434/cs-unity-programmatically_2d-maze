using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEngine : MonoBehaviour
{
    public GameObject pigModel;
    public GameObject tileModel;
    public GameObject towerModel;
    public GameObject doorModel;
    public GameObject devilModel;
    public Camera mainCamera;

    private Player player;
    private Tile[][] path;

    void Start()
    {
        int w = 10;
        int h = 10;
        path = new Tile[h][];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = new Tile[w];
            for (int i2 = 0; i < path[i].Length; i2++)
            {
                GameObject tileObj = tileModel;
                bool isTower = false;

                if (i == 0 || i == h - 1 || i2 == 0 || i2 == w - 1 || UnityEngine.Random.value < 0.1f)
                {
                    tileObj = towerModel;
                    isTower = true;
                }

                GameObject instance = MonoBehaviour.Instantiate(tileObj, new Vector3(i2 * 2, 0, i * 2), Quaternion.identity);
                path[i][i2] = new Tile(instance, isTower);
            }
        }

        GameObject playerSpawnPos = path[2][2].obj;
        Debug.Log(playerSpawnPos.transform.position);
        GameObject playerObj = Instantiate(pigModel, playerSpawnPos.transform.position, Quaternion.identity);
        player = new Player(playerObj);
        Debug.Log("Player instantiated: " + (player != null));
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player is not instantiated!");
            return;
        }

        player.DoMove(path);
        mainCamera.transform.position = player.obj.transform.position + new Vector3(0, 15, 0);
    }
}