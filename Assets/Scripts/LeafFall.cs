using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFall : MonoBehaviour {

    Rigidbody2D _rigidbody;
    public float fallSpeed = 1;
    private float _time = 20.0f;
    private float _timer = 0.0f;
    private float _offset;

	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _offset = Random.Range(-2.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -fallSpeed);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Water")
        {
            fallSpeed = 0.2f;
            Destroy(gameObject, _time);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Water")
        {
            float angle = Mathf.LerpAngle(0f, 30.0f, _timer * 0.05f);
            transform.eulerAngles = new Vector3(0, 0, angle * _offset);
            _timer += Time.deltaTime;
        }
    }
}
