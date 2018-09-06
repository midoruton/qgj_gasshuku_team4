using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardScroll : MonoBehaviour {
    public float speed;
    public bool loop;
    private float spriteHeight;
    private Vector3 r0;
    private float shift=0;
	// Use this for initialization
	void Start () {
        r0 = gameObject.transform.position;
        var Ch = transform.Find("bg_loop_wall (1)");
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;//Ch.transform.position.y - r0.y;
        //Debug.Log(spriteHeight);
        //Debug.Log(GetComponent<SpriteRenderer>().bounds.size.y);

    }
	
	// Update is called once per frame
	void Update () {
        shift += speed * Time.deltaTime;
        if (loop)
        {
            while (shift > spriteHeight)
            {
                shift -= (int)(shift/spriteHeight)*spriteHeight;
            }
        }
        gameObject.transform.position = r0 + new Vector3(0, -shift, 0);
    }
}
