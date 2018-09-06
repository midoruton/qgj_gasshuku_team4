using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour {

    private Camera _camera;

	// Use this for initialization
	void Start ()
    {
        _camera = GetComponent<Camera>();

        float targetRatio = 16.0f / 9.0f;

        float currentRatio = Screen.width * 1f / Screen.height;

        float ratio = targetRatio / currentRatio;

        float rectX = (1.0f - ratio) / 2.0f;

        _camera.rect = new Rect(rectX, 0f, ratio, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
