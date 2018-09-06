using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;

    public PlayerEnum playerType;
    private Rigidbody2D rb2D;
    private bool ableToJump = false;
    private Foot foot;

    // Use this for initialization
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        foot = transform.Find("Foot").GetComponent<Foot>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 newVel = new Vector2(0,0);
        float x = 0;
        float y = 0;
        if (playerType == PlayerEnum.Player1)
        {
            x = Input.GetAxis("Horizontal1");
            y = Input.GetAxis("Vertical1");
        }else{
            x = Input.GetAxis("Horizontal2");
            y = Input.GetAxis("Vertical2");
        }
        if (x>0)
        {
            newVel.x += moveSpeed;
        }
        if (x<0)
        {
            newVel.x += -moveSpeed;
        }
        ableToJump = foot.OnLeaf;
        if (ableToJump&&y>0)
        {
            newVel.y = jumpSpeed;
            ableToJump = false;
        }
        newVel.y += rb2D.velocity.y;
        rb2D.velocity = newVel;
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
