using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitsUIManager : MonoBehaviour {

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
        text.text = "Falls " + gameData.fall.ToString() + "\r\nHits " + gameData.hit.ToString() + "\r\n";
    }
}
