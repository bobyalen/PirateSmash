using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    Attack playerAttack;
    BlockManager playerBlock;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    [SerializeField]
    public float attackDelay = 1.0f;

    private float horizontal;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float jumpingPower = 16f;
    private bool isFacingRight = true;


    private void Start()
    {
        playerAttack = GetComponent<Attack>();
        playerBlock = GetComponent<BlockManager>();
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        if (animator.GetBool("IsJumping"))
        {
            if (IsGrounded())
            {
                animator.SetBool("IsJumping", false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("player is grounded and w is pressed");

        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            animator.SetBool("IsJumping", false);

        }
    }



    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!attackPlaying())
        {
            animator.SetTrigger("Attack");
            Debug.Log("player is attacking and q is pressed");
            playerAttack.playerAttack();
        }

        //StartCoroutine(DelayAttack());
    }
    
    public void Block(InputAction.CallbackContext context)
    {
        if(!playerBlock.blocked)
        {
            playerBlock.playerBlock();
            Debug.Log("Blocking: " + playerBlock.blocked);
        }

    }

    bool attackPlaying()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            // Avoid any reload.
            return true;
        }
        return false;
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
    }
}
