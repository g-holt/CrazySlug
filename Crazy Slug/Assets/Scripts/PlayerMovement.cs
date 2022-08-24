using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float springSpeed = 5f;

    Vector2 moveInput;
    Animator animator;
    Animation move;
    Animation idle;
    SpriteRenderer spriteRenderer;
    MushroomSpring mushroomSpring;

    float moveX;
    float moveY;
    string moveAnim;
    string idleAnim;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        mushroomSpring = FindObjectOfType<MushroomSpring>();

        idleAnim = "Idle";
        moveAnim = "Move";
        animator.SetBool(idleAnim, true);
    }

    
    void Update()
    {
        Move();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.CompareTag("MushroomSpring"))
        {
            mushroomSpring.ActivateSpring();
            SpringJump();
        }     
    }


    void Move()
    {
        if (moveInput.x == 0)
        {
            animator.SetBool(idleAnim, true);
            animator.SetBool(moveAnim, false);
            return;
        }

        FlipSprite();

        animator.SetBool(idleAnim, false);
        animator.SetBool(moveAnim, true);

        moveX = moveInput.x * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, 0f, 0f, Space.Self);
    }


    void FlipSprite()
    {
        if (moveInput.x == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x == 1)
        {
            spriteRenderer.flipX = false;
        }
    }


    void SpringJump()
    {
        moveY = springSpeed * Time.deltaTime;

        /*Change to Lerp for smooth jump" */
        transform.Translate(moveX, moveY, 0f, Space.Self);
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
