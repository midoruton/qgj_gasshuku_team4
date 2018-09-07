using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    private PlayerController playerController;
    private InputToungeAction inputTongue;
    private bool isJumpPush = false;
    private bool isJumping = false;
    private bool  isWalking = false;
    private bool isToungePush = false;
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rigid = this.GetComponent<Rigidbody2D>();
        playerController = this.GetComponent<PlayerController>();
        inputTongue = this.GetComponent<InputToungeAction>();
    }

    private void Start()
    {
        playerController.JumpAction = () =>
        {
            isJumpPush = true;
        };


        inputTongue.toungeBeforeAction = () =>
        {
            isToungePush = true;
            animator.Play("TongeBefore");
        };
        inputTongue.pushAction = () =>
        {
            isToungePush = true;
            Invoke("SetToungePushFalse", 0.1f);
            animator.Play("Tounge");
        };
        inputTongue.stopChargeAction = () =>
        {
            isToungePush = false;
            animator.Play("Stand");
        };

    }


    private void Update()
    {
        if(rigid.velocity.x>0){
            spriteRenderer.flipX = true;
        }else if(rigid.velocity.x<0){
            spriteRenderer.flipX = false;
        }

        if(isToungePush){
            return;
        }
        if (!isJumping)
        {
            if (Mathf.Abs(rigid.velocity.x) > 0.1f)
            {
                if (!isWalking)
                {
                    animator.Play("WalkAnimation");
                    isWalking = true;
                }
            }
            else
            {
                animator.Play("Stand");
                isWalking = false;
            }

            if(isJumpPush){
                animator.Play("JumpUp");
                isJumping = true;
                isJumpPush = false;
            }

            if (!playerController.foot.OnLeaf&&rigid.velocity.y<-0.1f)
            {
                animator.Play("JumpUp");
                isJumping = true;
                isWalking = false;
            }
        }else {
            


            if (isJumpPush)
            {
                animator.Play("JumpUp");
                isJumping = true;
                isJumpPush = false;
            }

            if(playerController.foot.OnLeaf){
                animator.Play("Stand");
                isJumping = false;
                isWalking = false;
            }
        }

    }
    void SetToungePushFalse(){
        isToungePush = false;
    }
}
