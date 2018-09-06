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
        Instantiate(Leaf, new Vector2(Random.Range(-6.0f, 6.0f), 15.0f), transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_timer >= timespan)
        {
            Instantiate(Leaf,new Vector2(Random.Range(-6.0f,6.0f),15.0f),transform.rotation);
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
	}
}
