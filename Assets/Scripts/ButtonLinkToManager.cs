using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLinkToManager : MonoBehaviour
{
    public int difficultyValue;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameManager.Instance.SetDifficulty(difficultyValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
