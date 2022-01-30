using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    public Animator anim;
    public int health;
    public float speed;
    public float jumpForce;
    public bool isDead;

    [Header("States Check")]
    public bool isGround;
    public bool canJump;
    public bool isJump;

    [Header("Ground Check")]
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if(health <= 0)
        {
            isDead = true;
        }
        anim.SetBool("dead", isDead);
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            PhysicsCheck();
            Movement();
            Jump();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 3;
            canJump = false;
        }
    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                rb.gravityScale = 1;
            }
            isJump = false;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("进入伤害范围");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("hit"))
        {
            Debug.Log("造成伤害");
            health -= damage;
            anim.SetTrigger("hit");
            if (health <= 0)
            {
                health = 0;
                //玩家死亡触发其他逻辑
            }
        }
    }
}
