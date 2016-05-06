using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour {
    private GameData gameData;
    private float MoneyTimer = 0.0f;
    float deltaMoneyTimer = 0.1f;

    void Start () {
        gameData = GameData.Instance;
	}
	
	void Update () {

        MoneyTimer += Time.deltaTime;
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
        if (gameData.speed <= 0.1)
            deltaMoneyTimer = 5;
        else if ((gameData.speed > 0.1) && (gameData.speed <= 0.2))
            deltaMoneyTimer = 4;
        else if (gameData.speed > 0.2)
            deltaMoneyTimer = 3;

        if (MoneyTimer >= deltaMoneyTimer)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
