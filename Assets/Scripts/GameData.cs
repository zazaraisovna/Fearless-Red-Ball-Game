using UnityEngine;
using System.Collections;

public class GameData : Singleton<GameData> {
    public int level = 1;
    public int fall = 0;
    public int hit = 0;
    public int restart = 0;
    public int bonus = 0;
    public float speed = 0.1f;
    public float gameTimer = 0f;
    public bool isGameOver = false;
    public bool isFall = false;
    public bool isHit = false;
    public bool isRestart = false;
    public bool isBonus = false;
    protected GameData()
    {

    }

    void Start () {
	
	}
	
	void Update () {
        if (isFall)
        {
            fall++;
            isFall = false;
        }
        if (isRestart)
        {
            restart++;
            isRestart = false;
        }
        if (isHit)
        {
            hit++;
            isHit = false;
        }
        if (isBonus)
        {
            bonus += 10;
            isBonus = false;
        }

        if (!isGameOver)
            gameTimer += Time.deltaTime;

        else if (isGameOver)
        {
            Application.LoadLevel(Application.loadedLevel);
            speed = 0.1f;
            bonus = 0;
            level = 1;
            gameTimer = 0;
            isGameOver = false;
        }
        
        if ((gameTimer >= 10) && (level == 1))
        {
            level = 2;
            speed = 0.15f;
        }
        if ((gameTimer >= 35f) && (level == 2))
        {
            level = 3;
            speed = 0.2f;
        }
        if ((gameTimer >= 55f) && (level == 3))
        {
            level = 4;
            speed = 0.25f;
        }
    }
}
