using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSporn : MonoBehaviour {

    public GameObject Leaf;
    public float timespan = 3.0f;
    private float _timer;
    private float _spornPos;
    private float _beforePos;

	// Use this for initialization
	void Start ()
    {
        _spornPos = Random.Range(-6.0f, 6.0f);
        _timer = 0.0f;
        Instantiate(Leaf, new Vector2(_spornPos, 15.0f), transform.rotation);
        _beforePos = _spornPos;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_timer >= timespan)
        {
            while(Mathf.Abs(_spornPos - _beforePos) < 2.5f)
            {
                _spornPos = Random.Range(-6.0f, 6.0f);
            }
            Instantiate(Leaf,new Vector2(_spornPos, 15.0f), transform.rotation);
            _timer = 0.0f;
            _beforePos = _spornPos;
        }

        _timer += Time.deltaTime;
	}
}
