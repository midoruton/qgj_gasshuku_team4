﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;

    private Rigidbody2D rb2D;
    private bool ableToJump = false;

    // Use this for initialization
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 newVel = new Vector2(0,0);
        if (Input.GetKey(KeyCode.D))
        {
            newVel.x += moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVel.x += -moveSpeed;
        }
        if (ableToJump&&Input.GetKeyDown(KeyCode.W))
        {
            newVel.y = jumpSpeed;
        }
        newVel.y += rb2D.velocity.y;
        rb2D.velocity = newVel;
	}

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
    }
}
