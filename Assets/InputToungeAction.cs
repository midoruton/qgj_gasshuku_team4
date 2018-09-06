using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToungeAction : MonoBehaviour {

    [SerializeField] private float toungeSpeed = 5f;
    [SerializeField] private float toungeTime = 2f;
    [SerializeField] private GameObject toungeFrontObj;
    private Coroutine toungeCoroutine = null;
    private Rigidbody2D toungeRigid;
	// Use this for initialization
	void Start () {
        toungeRigid = toungeFrontObj.GetComponent<Rigidbody2D>();
        if(toungeRigid==null){
            Debug.LogError("舌オブジェクトにRigidbody2Dがアタッチされていません。");
        }
        }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Tounge")) {
            
            if (toungeCoroutine == null)
            {
                toungeCoroutine = StartCoroutine(ToungeCorotine());
            }

        }
	}

    private IEnumerator ToungeCorotine(){
        ResetTounge();
        var inputVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float time = 0f;
        while(time <=toungeTime){
            toungeRigid.transform.Translate(inputVec.normalized * toungeSpeed,Space.Self);
            yield return new  WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        time = 0f;
        while(time <=toungeTime){
            toungeRigid.transform.Translate(-1f*inputVec.normalized * toungeSpeed, Space.Self);
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        ResetTounge();
        toungeCoroutine = null;
    }

    private void ResetTounge()
    {
        toungeRigid.velocity = Vector2.zero;
        toungeFrontObj.transform.position = this.transform.position;
    }
}
