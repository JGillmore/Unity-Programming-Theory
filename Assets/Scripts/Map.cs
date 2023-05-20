using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int mapSize;
    private int[,] map;
    private int bombs;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap(GameManager.Instance.gameDifficulty);
    }

    private void CreateMap(int difficulty)
    {
        bombs = 10 * difficulty * difficulty;
        mapSize = difficulty * 5 + 5;
        map = new int[mapSize,mapSize];
        DebugLogMap();
        PopulateMap(bombs);
        DebugLogMap();
    }

    private void PopulateMap(int i)
    {
        while (i > 0)
        {
            int x = Random.Range(0, mapSize);
            int y = Random.Range(0, mapSize);

            if (map[x,y] < 9)
            {
                map[x,y] = 9;
                AddOneToAdjacentTiles(x, y);
                i--;
            }
        }
    }

    private void AddOneToAdjacentTiles(int x, int y)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (TileIsValid(x - 1 + i, y - 1 + j))
                {
                    AddOneToNumberTiles(x - 1 + i, y - 1 + j);
                }
            }
        }
    }

    private void AddOneToNumberTiles(int x, int y)
    {
        if (map[x,y] < 9)
        {
            map[x, y] += 1;
        }
    }

    void DebugLogMap() // can be removed for build
    {
        string lineToPrint = "";
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                lineToPrint += map[i, j] + ", ";
            }
            lineToPrint += "\n";
        }
        Debug.Log(lineToPrint);
    }

    private bool TileIsValid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < mapSize && y < mapSize;
    }
}