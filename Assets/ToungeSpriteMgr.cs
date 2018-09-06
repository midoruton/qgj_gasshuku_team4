using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeSpriteMgr : MonoBehaviour {

    [SerializeField] private GameObject toungeFrontObj;
    [SerializeField] private GameObject spriteObj;
    [SerializeField] private GameObject objRefPos;
    [SerializeField] private Transform playerPos;
    private SpriteRenderer toungeSpriteRenderer;
    
    private Vector2 defaultSize;
    private void Awake()
    {
        toungeSpriteRenderer = spriteObj.GetComponent<SpriteRenderer>();
        defaultSize = toungeSpriteRenderer.size;
        spriteObj.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(playerPos.gameObject.GetComponent<InputToungeAction>().toungeCoroutine==null){
            spriteObj.SetActive(false);
        }else{
            spriteObj.SetActive(true);
        }
        spriteObj.transform.up = toungeFrontObj.transform.position - this.transform.position;

        var diff = (toungeFrontObj.transform.position - this.transform.position).magnitude;
        toungeSpriteRenderer.size = new Vector2(defaultSize.x, diff);
        objRefPos.transform.localPosition = (toungeFrontObj.transform.position - this.transform.position) / 2f;
	}
}
