using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLeafFall : MonoBehaviour {

    public float fallspeed = 0.3f;
    private float _timer;
    private Rigidbody2D _rigidbody;
    private float nowTime = 0f;

	// Use this for initialization
	void Start ()
    {
        _timer = Random.Range(15.0f, 25.0f);
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(nowTime >= _timer)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -fallspeed);
        }

        if(transform.position.y <= -10.0)
        {
            Destroy(gameObject);
        }
        nowTime += Time.deltaTime;
	}
}
