using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {

    private bool onLeaf = false;
    private bool hitOnLeaf = false;

    public bool OnLeaf
    {
        get
        {
            return onLeaf;
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            onLeaf = true;
            hitOnLeaf = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            onLeaf = true;
            hitOnLeaf = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            onLeaf = false;
            hitOnLeaf = false;
        }
    }
}
