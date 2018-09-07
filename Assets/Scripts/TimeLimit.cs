using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour {

    public float Limit = 100.0f;
    public GameObject Finish;
    private Text _timeText;
    private bool _goFinish = true;

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

        if(_goFinish && Limit < 0.7f)
        {
            Instantiate(Finish, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

            _goFinish = false;
        }

        if(Limit <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
	}
}
