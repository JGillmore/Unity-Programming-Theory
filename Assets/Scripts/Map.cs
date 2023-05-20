using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public Tile tile;
    public Button mainMenuButton;

    private int mapSize;
    private Tile[,] map;
    private int bombs;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap(GameManager.Instance.gameDifficulty);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CreateMap(int difficulty)
    {
        bombs = 10 * difficulty * difficulty;
        mapSize = difficulty * 5 + 5;
        map = new Tile[mapSize,mapSize];
        InitializeMap(mapSize);
        PopulateMap(bombs);
    }

    private void InitializeMap(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                map[i, j] = Instantiate(tile) as Tile;
                map[i, j].value = 0;
                Debug.Log("initializing: " + i + "," + j + " with value: " + map[i, j].value);
                GridPlacement(i, j);
            }
        }
    }

    private void PopulateMap(int i)
    {
        while (i > 0)
        {
            int x = Random.Range(0, mapSize);
            int y = Random.Range(0, mapSize);

            if (map[x,y].value < 9)
            {
                map[x,y].value = 9;
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
        if (map[x,y].value < 9)
        {
            map[x, y].value += 1;
        }
    }

    private bool TileIsValid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < mapSize && y < mapSize;
    }

    private void GridPlacement(int i, int j)
    {
        map[i, j].transform.position = new Vector3(i - mapSize / 2 + .5f, 0, j - mapSize / 2 +.5f);
        Debug.Log("Placement for " + i + "," + j + " is " + map[i, j].transform.position);
    }
}