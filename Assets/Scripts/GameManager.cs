using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private float CreatePlatformTimer = 0.0f;
    private float CreateMiddlPlatformTimer = 0.0f;
    private float CreateEnemyTimer = 0.0f;
    private float CreateMoneyTimer = 0.0f;
    GameObject[] PlatformsGameObject;
    private GameData gameData;

    void Start () {
        gameData = GameData.Instance;
        PlatformsGameObject = new GameObject[4];
        PlatformsGameObject[0] = (GameObject)Resources.Load("Prefab/platform", typeof(GameObject));
        PlatformsGameObject[1] = (GameObject)Resources.Load("Prefab/platform2", typeof(GameObject));
        PlatformsGameObject[2] = (GameObject)Resources.Load("Prefab/cube_with_sharp", typeof(GameObject));
        PlatformsGameObject[3] = (GameObject)Resources.Load("Prefab/money", typeof(GameObject));

        if (PlatformsGameObject[0] != null)
        {
            Generate(PlatformsGameObject[1], -8f, 1.5f);
            Generate(PlatformsGameObject[1], -8f, -1f);

            Generate(PlatformsGameObject[1], 0f, 3f);
            Generate(PlatformsGameObject[1], 0f, 0.5f);

            Generate(PlatformsGameObject[1], 8f, 1.5f);
            Generate(PlatformsGameObject[1], 8f, -1f);
        }
    }
	
	void Update () {
        CreateEnemyTimer += Time.deltaTime;
        if (CreateEnemyTimer >= (60f * gameData.speed))
        {
            Generate(PlatformsGameObject[2], Random.Range(-8f, 8f), 5f);

            CreateEnemyTimer = 0.0f;
        }
        CreateMoneyTimer += Time.deltaTime;
        if (CreateMoneyTimer >= (0.2f / 0.1f))
        {
            int caseSwitch = Random.Range(0, 6);
            switch (caseSwitch)
            {
                case 0:
                    Generate(PlatformsGameObject[3], -8.1f, 2f);
                    break;
                case 1:
                    Generate(PlatformsGameObject[3], -8.1f, -0.5f);
                    break;
                case 2:
                    Generate(PlatformsGameObject[3], 0f, 3.5f);
                    break;
                case 3:
                    Generate(PlatformsGameObject[3], 0f, 1f);
                    break;
                case 4:
                    Generate(PlatformsGameObject[3], 8f, 2f);
                    break;
                case 5:
                    Generate(PlatformsGameObject[3], 8f, -0.5f);
                    break;
                default:
                    Generate(PlatformsGameObject[3], 8f, 2f);
                    break;
            }
          
            CreateMoneyTimer = 0.0f;
        }
        /* CreatePlatformTimer += Time.deltaTime;
        if (CreatePlatformTimer >= (0.6f / 0.1f))
        {
            Generate(PlatformsGameObject[0], -6.5f, 5f);
            Generate(PlatformsGameObject[0], 2.5f, 5f);

            CreatePlatformTimer = 0.0f;
        }
        CreateMiddlPlatformTimer += Time.deltaTime;
        if (CreateMiddlPlatformTimer >= (0.7f / 0.1f))
        {
            Generate(PlatformsGameObject[0], -2f, 4.3f);
            Generate(PlatformsGameObject[0], 7f, 4.3f);

            CreateMiddlPlatformTimer = 0.0f;
        }*/
        Debug.Log("Falls " + gameData.fall.ToString() + ", Restart " + gameData.restart.ToString()
             + ", Hit " + gameData.hit.ToString() + ", Bonus " + gameData.bonus.ToString()
              + ", Speed " + gameData.speed.ToString());
    }

    void Generate(GameObject go, float posX, float posY)
    {
        GameObject GO;
        GO = (GameObject)Instantiate(go);
        GO.transform.position = new Vector2(posX, posY);
    }
}
