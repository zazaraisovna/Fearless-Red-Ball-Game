using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

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
        text.text = "Bonus " + gameData.bonus.ToString() + "\r\nSpeed " + (gameData.speed * 100).ToString() + "\r\n";
    }
}
