using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour {

    public GameObject Frog;
    public Text Point;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Point.text = Frog.GetComponent<PlayerHitpoint>().DeathCounter.ToString();
	}
}
