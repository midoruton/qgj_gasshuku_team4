using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    private float _timer = 0.0f;
    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 0.5f);
	}

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.3f + _timer * 5, 0.3f + _timer * 5, 1);
        _spriteRenderer.color = new Color(255, 255, 255, 2 * (0.5f - _timer));
        _timer += Time.deltaTime;
	}
}
