using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float wallJumpReaction;


    public Action JumpAction;
    public PlayerEnum playerType;
    enum State
    {
        OnLeaf,
        Flying,
        OnLeftWall,
        OnRightWall,
    }
    [SerializeField] private GameObject particleSys;
    [SerializeField] private GameObject dashEffect;
    [SerializeField] private AudioClip hitClip;
    private State st = State.Flying;
    private Rigidbody2D rb2D;
    private bool ableToJump = false;
    private bool ableToWallJump = false;
    private int jumpCount = 0;
    public Foot foot;
    private WallSensor ws;


    private Coroutine TenmetuCorotuine;

    private bool isImpact = false;
    private bool canDash = true;
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
        //dash処理
        if (!ableToJump)
        {
            
            Vector3 vector = (new Vector3(newVel.x, newVel.y, 0f)).normalized;
            if (vector.y < 0f) vector.y = 0f;


            if (playerType == PlayerEnum.Player1)
            {
                if (Input.GetButtonDown("Jump1"))
                {


                    if (vector == Vector3.zero) return;
                    rb2D.MovePosition(this.transform.position + vector*2f);

                    canDash = false;
                    Invoke("SetCanDashTrue", 0.1f);
                    var d = Instantiate(dashEffect, this.transform.position, Quaternion.identity);
                    d.transform.up = vector;

                    return;
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump1"))
                {
                    if (vector == Vector3.zero) return;
                    rb2D.MovePosition(this.transform.position + vector * 2f);
                    canDash = false;
                    Invoke("SetCanDashTrue", 0.1f);
                    var d = Instantiate(dashEffect, this.transform.position, Quaternion.identity);
                    d.transform.up = vector;
                    return;
                }

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
        }else if(rb2D.velocity.y<-0.1f){
            if (x > 0)
            {
                newVel.x = moveSpeed*1.2f;
            }
            if (x < 0)
            {
                newVel.x = -moveSpeed*1.2f;
            }
            if (x == 0)
            {
                newVel.x = 0;
            }


        }

        if ((foot.OnLeaf) || (ws.OnWall))
        {
            ableToJump = true;
        } 

        if (ableToJump&&isJumpPushed)
        {
            newVel.x = x*jumpSpeed;
            newVel.y = jumpSpeed;
            jumpCount++;
            ableToJump = false;
            if (JumpAction != null) JumpAction();
        }
        //newVel.y += rb2D.velocity.y;
        rb2D.velocity = newVel;

        if (jumpCount >= 1 && foot.OnLeaf && rb2D.velocity.y<=0)
        {
            jumpCount = 0;
        }
    }

    public void Impact(float impactTime){
        if (isImpact) return;
        this.GetComponent<AudioSource>().clip = hitClip;
        this.GetComponent<AudioSource>().Play();
        isImpact = true;
        if(TenmetuCorotuine==null){
            TenmetuCorotuine = StartCoroutine(Tenmetu());
        }
        Invoke("SetImpactFalse", impactTime);
        Instantiate(particleSys, this.transform);
        this.GetComponent<InputToungeAction>().ResetCharge();
    }

    IEnumerator Tenmetu(){
        while(true){
            Color old = this.GetComponent<SpriteRenderer>().material.color;
            this.GetComponent<SpriteRenderer>().material.color = new Color(old.r,old.g,old.b,0f);
            yield return new WaitForSeconds(0.05f);
            this.GetComponent<SpriteRenderer>().material.color = old;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void SetImpactFalse(){
        isImpact = false;
        this.GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f,1f);
        StopCoroutine(TenmetuCorotuine);
        TenmetuCorotuine = null;
    }

    private void SetCanDashTrue(){
        canDash = true;
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
