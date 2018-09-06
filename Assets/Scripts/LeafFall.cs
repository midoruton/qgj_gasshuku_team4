using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFall : MonoBehaviour {

    Rigidbody2D _rigidbody;
    public float fallSpeed = 1;

	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -fallSpeed);
	}
}
