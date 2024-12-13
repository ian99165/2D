using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public bool gamestart_ = false;

    private int jumpCount = 0;
    private const int maxJumpCount = 2;

    public float moveSpeed = 5f; // 移動速度

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gamestart_) return;

        bool isMoving = false;

        // 左移
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y); // 固定水平速度
            transform.localScale = new Vector2(-1, 1);
            animator.SetBool("running", true);
            isMoving = true;
        }
        // 右移
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y); // 固定水平速度
            transform.localScale = new Vector2(1, 1);
            animator.SetBool("running", true);
            isMoving = true;
        }
        else
        {
            // 沒有按下左右鍵，將水平速度設為0
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y); // 停止水平方向移動
            animator.SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            if (gamestart_)
            {
                gamestart_ = false;

                GameObject _canvas = GameObject.Find("Canvas");
                ButtonClicked _button_clicked = _canvas.GetComponent<ButtonClicked>();
                _button_clicked.Open_Playing_Canvas();
            }
        }
    }

    public void SetGameStart()
    {
        gamestart_ = true;
    }

    private void Jump()
    {
        if (jumpCount < maxJumpCount)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5.0f); // 垂直跳躍
            jumpCount++;
            animator.SetTrigger("jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            animator.SetBool("jumping", false);
        }

        if (collision.gameObject.CompareTag("end"))
        {
            SceneManager.LoadScene("S2");
        }
    }
}
