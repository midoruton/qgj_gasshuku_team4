using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour {

    bool ChangingScene = false;
    float t = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!ChangingScene)
        {
            if (Input.GetButtonDown("Submit"))
            {
                var auds = GetComponent<AudioSource>();
                auds.PlayOneShot(auds.clip);
                ChangingScene = true;
            }
        }
        else
        {
            t += Time.deltaTime;
            if (t > 0.5)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
            }
        }
	}
}
