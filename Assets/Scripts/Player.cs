using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 0.01f;
    private bool faceRight = true;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    [SerializeField] float JumpForce = 13f;
    [SerializeField] LayerMask layerCanJump;
    bool ExtraJump = true;
    public GameObject smokeEffect;
    Animator anim;

    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float dashDistance = 3f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector2 playerScale = this.transform.localScale;
        playerScale.x = playerScale.x * -1;
        this.transform.localScale = playerScale;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashDistance, 0f);
 
        yield return new WaitForSeconds(dashTime);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDashing == true)
        {
            return;
        }
        Move();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if(hit.collider!= null)
        {
            if(hit.distance > 1f)
            {
                anim.SetTrigger("isFalling");
            }
            else if(hit.distance < 1.1f)
            {
                anim.SetTrigger("isLanding");
            }
        }
    }

    public void Move()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
            RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0.015f, Vector2.down, 0.1f, layerCanJump);
            if (hit.collider != null) //check if grounded
            {
                ExtraJump = true;
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
            else
            {
                if(ExtraJump == true) 
                {
                    anim.SetTrigger("isJumping");
                    rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                    ExtraJump = false;
                }
            }
        }

        //move
        Vector3 playerPos = this.transform.position;
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("isWalking");
            playerPos.x = playerPos.x + MoveSpeed;
            this.transform.position = playerPos;
            if (faceRight == false)
            {
                Flip();
            }
        }
        //move left
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("isWalking");
            playerPos.x = playerPos.x - MoveSpeed;
            this.transform.position = playerPos;
            if (faceRight == true)
            {
                Flip();
            }
        }

        //dash
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            StartCoroutine(Dash());
            anim.SetTrigger("isRunning");
        }
        else
        {
            anim.SetTrigger("isIdle");
        }
    }
}
