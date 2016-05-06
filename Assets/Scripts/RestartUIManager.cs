using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartUIManager : MonoBehaviour {

    private GameData gameData;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        gameData = GameData.Instance;
    }

    void Update()
    {
        text.text = "Restart " + gameData.restart.ToString() + "\r\n";
    }
}
