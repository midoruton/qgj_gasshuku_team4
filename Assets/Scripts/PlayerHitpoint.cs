using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour {

    [SerializeField] GameObject splashEffect;
    [SerializeField] private AudioClip fallClip;
    [SerializeField] private Transform SpawnPoint;
     
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
            transform.position = SpawnPoint.transform.position;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            DeathCounter += 1;
            this.GetComponent<AudioSource>().clip = fallClip;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
