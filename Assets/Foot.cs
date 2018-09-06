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

    public bool HitOnLeaf
    {
        get
        {
            return hitOnLeaf;
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Leaf")
        {
            onLeaf = true;
            hitOnLeaf = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            onLeaf = true;
            hitOnLeaf = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Leaf")
        {
            onLeaf = false;
            hitOnLeaf = false;
        }
    }
}
