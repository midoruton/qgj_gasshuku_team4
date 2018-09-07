using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour {

    [SerializeField] GameObject splashEffect;
    public int DeathCounter = 0;

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
            Instantiate(splashEffect, this.transform.position, Quaternion.identity);
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            DeathCounter += 1;
            Debug.Log(DeathCounter);

        }
    }
}
