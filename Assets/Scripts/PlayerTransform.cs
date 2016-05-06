using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {
    public float maxSpeed = 10f;
    public float jumpForce = 600;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    Rigidbody2D PlayerRigidbody;
    public LayerMask whatIsGameover;
    bool gameover = false;
    public float move;

    private GameData gameData;

    void Start () {
        gameData = GameData.Instance;
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gameover = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGameover);
        if (gameover)
            return;

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
    }

    void Update () {
        if (!gameover)
        {
            if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
            {

                PlayerRigidbody.AddForce(new Vector2(0f, jumpForce));
            }
            PlayerRigidbody.velocity = new Vector2(move * maxSpeed, PlayerRigidbody.velocity.y);

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.R))
            {
                if (grounded)
                {
                    gameData.isRestart = true;
                    gameData.isGameOver = true;
                }
            }
        }
        else {
            gameData.isFall = true;
            gameData.isGameOver = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            gameData.isHit = true;
            gameData.isGameOver = true;
        }
        if (coll.gameObject.tag == "Money")
        {
            gameData.isBonus = true;
        }
    }
}
