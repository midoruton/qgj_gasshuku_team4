using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
    public List<Sprite> graphs;


    private Image im;
    private bool lastTimePressed = false;
    private int progress = 0;
	// Use this for initialization
	void Start () {
        im = GetComponent<Image>();
        im.sprite = graphs[0];

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            if (!lastTimePressed)
            {
                progress++;
                if (progress >= graphs.Count)
                {
                    SceneManager.LoadScene("GameScene");
                }
                else
                {
                    im.sprite = graphs[progress];
                }
            }
            lastTimePressed = true;
        }
        else
        {
            lastTimePressed = false;
        }
        Debug.Log(progress);
	}
}
