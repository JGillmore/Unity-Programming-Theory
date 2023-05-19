using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private int gameDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        gameDifficulty = GameManager.Instance.gameDifficulty;
        Debug.Log(gameDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
