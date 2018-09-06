using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSporn : MonoBehaviour {

    public GameObject Leaf;
    public float timespan = 3.0f;
    private float _timer;

	// Use this for initialization
	void Start ()
    {
        _timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_timer >= timespan)
        {
            Instantiate(Leaf,new Vector2(Random.Range(-10.0f,10.0f),20.0f),transform.rotation);
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
	}
}
