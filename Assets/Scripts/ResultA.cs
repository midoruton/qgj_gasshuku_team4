using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultA : MonoBehaviour {

    private Text _result;

	// Use this for initialization
	void Start ()
    {
        _result = GetComponent<Text>();
        _result.text = ResultCounter.GetFrogAResult().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
