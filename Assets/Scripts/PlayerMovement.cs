﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //gives us access to the object controller of type CharacterController2D

    public Animator animator;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;

    public AudioClip jumpClip;

    private float potionTimeMax = 10f;
    private float potionTimeCur = 0;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;

    bool soundPlayed = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //see if the player's speed is greater than or less than 0

        if (jumpFlag)
        {
            animator.SetBool("IsJumping", true);
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

            if (soundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                soundPlayed = true;
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", true);
        jump = false;
        soundPlayed = false;
    }

    void FixedUpdate()
    {
        if (hasJumpPotion && potionTimeCur < potionTimeMax)
        {
            controller.m_JumpForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            potionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            hasJumpPotion = false;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if(jump)
        {
            jumpFlag = true;
        }
    }

}
