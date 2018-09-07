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
    private AudioSource auds;
    private bool changingScene = false;
    private float t = 0;
	// Use this for initialization
	void Start () {
        im = GetComponent<Image>();
        im.sprite = graphs[0];
        auds = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!changingScene)
        {
            if (Input.GetButtonDown("Submit"))
            {
                if (!lastTimePressed)
                {
                    progress++;
                    if (progress >= graphs.Count)
                    {
                        auds.PlayOneShot(auds.clip);
                        changingScene = true;
                    }
                    else
                    {
                        im.sprite = graphs[progress];
                        auds.PlayOneShot(auds.clip);
                    }
                }
                lastTimePressed = true;
            }
            else
            {
                lastTimePressed = false;
            }
        }
        else
        {
            t += Time.deltaTime;
            if (t > 0.5)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        Debug.Log(progress);
	}
}
