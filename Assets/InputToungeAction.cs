using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToungeAction : MonoBehaviour {

    [SerializeField] private PlayerEnum playerType;
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
        
        bool isPushed = false;
        if (playerType == PlayerEnum.Player1)
        {
            if (Input.GetButtonDown("Tounge1"))
            {
                isPushed = true;
            }
        }
        else{
            if (Input.GetButtonDown("Tounge2"))
            {
                isPushed = true;
            }
        }
        if (isPushed) {
            
            if (toungeCoroutine == null)
            {
                toungeCoroutine = StartCoroutine(ToungeCorotine());
            }

        }
	}

    private IEnumerator ToungeCorotine(){
        ResetTounge();
        Vector2 inputVec = Vector2.zero;
        bool isLeafTouch = false;
        toungeFrontObj.GetComponent<ToungeFront>().onHitLeafAction = () =>
        {
            isLeafTouch = true;
        };
        if (playerType == PlayerEnum.Player1)
        {
            inputVec = new Vector2(Input.GetAxis("Horizontal1"), -1f*Input.GetAxis("Vertical1"));
        }else{
            inputVec = new Vector2(Input.GetAxis("Horizontal2"), -1f*Input.GetAxis("Vertical2"));
        }

        if(inputVec==Vector2.zero){
            ResetTounge();
            toungeCoroutine = null;
            yield break;

        }
        float time = 0f;
        while(time <=toungeTime&&!isLeafTouch){
            toungeRigid.transform.Translate(inputVec.normalized * toungeSpeed,Space.Self);
            yield return new  WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        while((this.transform.position-toungeFrontObj.transform.position).magnitude>0.1f){
            toungeRigid.transform.Translate(-1f*inputVec.normalized * toungeSpeed, Space.Self);
            yield return new WaitForFixedUpdate();
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
