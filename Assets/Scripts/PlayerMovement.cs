using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public float speed = 2, jumpForce = 2;
    public int jumpCount = 2;
    private int currentJumpCount = 0;
    [HideInInspector] public bool isGrounded = true;
    public float rightBorderPosition, leftBorderPosition;
    public bool left, right, jump;
    public int hp = 3;
    [HideInInspector] public bool isDamaged = false, damage;
    [HideInInspector] public float heigth;
    public int highScore = 1;

    public Text text;
    public GameObject gameOverPanel;
    public GameObject button1,button2,button3;

    [HideInInspector] public bool leftPressed, rightPressed, gameOver;

    private bool cooldownVisible;
    private int frameNumber = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highScore = PlayerPrefs.GetInt("HighScore");

        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        currentJumpCount = jumpCount;
        rightBorderPosition = GameObject.FindGameObjectWithTag("RightBorder").transform.position.x;
        leftBorderPosition = GameObject.FindGameObjectWithTag("LeftBorder").transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamaged == true)
        DamageAnimation();


        if (hp > 0)
        {
            Movement();
            Jump();
        }
        AnimationsControl();

        if(hp <= 0 && gameOver == false)
        {
            animator.SetTrigger("GameOver");
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            StartCoroutine(WaitGameOver());
            gameOver = true;
        }

        if(damage == true)
        {
            TakeDamage();
            damage = false;
        }
    }

    public void LeftDown()
    {
        leftPressed = true;
    }

    public void LeftUp()
    {
        leftPressed = false;
    }

    public void RightDown()
    {
        rightPressed = true;
    }

    public void RightUp()
    {
        rightPressed = false;
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow) || rightPressed == true)
        {
            if (gameObject.transform.position.x < rightBorderPosition)
            {
                gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
                right = true;
            }
        }
        else right = false;

        if (Input.GetKey(KeyCode.LeftArrow) || leftPressed == true)
        {
            {
                if (gameObject.transform.position.x > leftBorderPosition)
                {
                    gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    left = true;
                }
            }
        }
        else left = false;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumpCount > 0)
            {
                animator.SetTrigger("Jump");
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                currentJumpCount--;
            }
        }
    }

    public void JumpButton()
    {

            if (currentJumpCount > 0)
            {
            animator.SetTrigger("Jump");
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                currentJumpCount--;
            }
        }
    

    public void TakeDamage()
    {
        if (isDamaged == false)
        {
            hp--;
            StartCoroutine(DamageCooldown());
        }
    }

    public void DamageAnimation()
    {
        if (cooldownVisible == false)
        {
            if (frameNumber == 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                frameNumber++;
                StartCoroutine(WaitVisible());
            }
            else if (frameNumber ==1)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
                frameNumber++;
                StartCoroutine(WaitVisible());
            }
            else
            {
                frameNumber = 0;
            }
        }
    }

    public void AnimationsControl()
    {
        if (right == true || left == true)
        {
            if (currentJumpCount == jumpCount)
            {
                animator.SetBool("isRun", true);
            }
            if (right == true)
                spriteRenderer.flipX = false;
            else if (left == true)
                spriteRenderer.flipX = true;
        }
        else animator.SetBool("isRun", false);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingGround")
        {
            if (currentJumpCount < jumpCount)
            {
                animator.SetTrigger("Landing");
            }

            if(gameObject.transform.position.y - collision.transform.position.y >= 1.3f)
            currentJumpCount = jumpCount;

            if(gameObject.transform.position.y < heigth)
            {
                TakeDamage();
                heigth = collision.gameObject.transform.position.y - 0.5f;
            }
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingGround")
            gameObject.transform.Translate(collision.gameObject.GetComponent<MovementPlatform>().getSpeed * Time.deltaTime, 0, 0);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingGround") && gameObject.transform.position.y - collision.transform.position.y >= 1.3f)
        {
            heigth = collision.gameObject.transform.position.y - 0.5f;
        }
    }

    public IEnumerator DamageCooldown()
    {
        isDamaged = true;
        yield return new WaitForSeconds(1f);
        isDamaged = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
    }

    public IEnumerator WaitVisible()
    {
        cooldownVisible = true;
        yield return new WaitForSeconds(0.1f);
        cooldownVisible = false;
    }

    public IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(2f);
        if (Mathf.RoundToInt(gameObject.transform.position.y) <= highScore)
        {
            text.text = "Score: " + Mathf.RoundToInt(gameObject.transform.position.y).ToString();
        }
        else
        {
            text.text = "New High Score: " + Mathf.RoundToInt(gameObject.transform.position.y).ToString();
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(gameObject.transform.position.y));
        }
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
