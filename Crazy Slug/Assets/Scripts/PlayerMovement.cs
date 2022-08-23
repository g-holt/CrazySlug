using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 moveInput;
    Animator animator;
    Animation move;
    Animation idle;

    float moveX;
    float moveY;
    string moveAnim;
    string idleAnim;

    
    void Start()
    {
        moveAnim = "player_movement";
        idleAnim = "player_idle";
        animator.SetBool(idleAnim, true);


        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
    }


    void Move()
    {
        if(moveInput.x == 0)
        {
            animator.SetBool(idleAnim, true);
            return; 
        }
        
        animator.SetBool(moveAnim, true);
       
        moveX = moveInput.x * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, 0f, 0f, Space.Self);
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
