using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float wallJumpReaction;

    public PlayerEnum playerType;
    enum State
    {
        OnLeaf,
        Flying,
        OnLeftWall,
        OnRightWall,
    }
    private State st = State.Flying;
    private Rigidbody2D rb2D;
    private bool ableToJump = false;
    private bool ableToWallJump = false;
    private int jumpCount = 0;
    private Foot foot;
    private WallSensor ws;


    private bool isImpact = false;
    // Use this for initialization
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        foot = transform.Find("Foot").GetComponent<Foot>();
        ws = transform.Find("WallSensor").GetComponent<WallSensor>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isImpact) return;
        Vector2 newVel = new Vector2(rb2D.velocity.x,rb2D.velocity.y);
        float x = 0;
        float y = 0;
        bool isJumpPushed = false;
        if (playerType == PlayerEnum.Player1)
        {
            x = Input.GetAxis("Horizontal1");
            y = Input.GetAxis("Vertical1");

            if (Input.GetButtonDown("Jump1"))
            {
                isJumpPushed = true;
            }
        }else{
            x = Input.GetAxis("Horizontal2");
            y = Input.GetAxis("Vertical2");
            if(Input.GetButtonDown("Jump2"))
            {
                isJumpPushed = true;
            }
        }

        if (foot.OnLeaf) {
            if (x>0)
            {
                newVel.x = moveSpeed;
            }
            if (x<0)
            {
                newVel.x = -moveSpeed;
            }
            if (x == 0)
            {
                newVel.x = 0;
            }
        }

        if ((jumpCount == 0 && foot.OnLeaf) || (jumpCount == 1 && ws.OnWall))
        {
            ableToJump = true;
        } 

        if (ableToJump&&isJumpPushed)
        {
            newVel.x = x*jumpSpeed;
            newVel.y = jumpSpeed;
            jumpCount++;
            ableToJump = false;
        }
        //newVel.y += rb2D.velocity.y;
        rb2D.velocity = newVel;

        if (jumpCount >= 1 && foot.OnLeaf && rb2D.velocity.y<=0)
        {
            jumpCount = 0;
        }
    }

    public void Impact(){
        if (isImpact) return;
        isImpact = true;
        Invoke("SetImpactFalse", 0.4f);
    }
    private void SetImpactFalse(){
        isImpact = false;
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Leaf")
        {
            Debug.Log("on leave");
            ableToJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            ableToJump = false;
        }
    }*/
}
