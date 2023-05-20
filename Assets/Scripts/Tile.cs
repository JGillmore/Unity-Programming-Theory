using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public GameObject dirtPile;
    public GameObject coin;
    public GameObject bomb;
    public TextMeshProUGUI valueText;
    public int value;

    public bool beenClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        valueText.text = "";
    }

    private void OnMouseUp()
    {
        if (beenClicked)
        {
            return;
        }
        beenClicked = true;
        if (value > 0 && value < 9)
        {
            valueText.text = value.ToString();  
        }else
        {
            valueText.text = "";
        }
        if (value == 9)
        {
            Instantiate(bomb).transform.position = transform.position + new Vector3(0, .2f, 0);
            GameOver();
            return;
        }
        dirtPile.transform.position += new Vector3(0,.14f,0);
        Instantiate(coin).transform.position = transform.position + new Vector3(0,.075f,0);
    }

    private void GameOver()
    {

    }
}
