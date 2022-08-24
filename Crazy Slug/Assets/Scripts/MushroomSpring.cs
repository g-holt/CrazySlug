using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpring : MonoBehaviour
{
    Animator animator;

    string springUp;


    void Start()
    {
        animator = GetComponent<Animator>();

        springUp = "SpringUp";
    }

    
    void Update()
    {
        
    }


    public void ActivateSpring()
    {Debug.Log("ActivateSpring");
        animator.SetBool(springUp, true);
    }


    public void ResetSpring()
    {Debug.Log("ResetSpring");
        animator.SetBool(springUp, false);
    }
}
