using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour {

    public int hitPoint = 3;
    public List<GameObject> Heart;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Water")
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //hitPoint -= 1;
            //Destroy(Heart[hitPoint]);


            //if(hitPoint == 0)
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
