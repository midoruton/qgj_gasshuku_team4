using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour {

    public float Limit = 100.0f;
    private Text _timeText;

	// Use this for initialization
	void Start ()
    {
        _timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Limit -= Time.deltaTime;
        _timeText.text = ((int)Limit).ToString();

        if(Limit <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
	}
}
