using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToungeAction : MonoBehaviour {

    [SerializeField] private PlayerEnum playerType;
    [SerializeField] private float toungeSpeed = 1f;
    [SerializeField] private float toungeBackSpeed = 0.2f;
    [SerializeField] private float toungeTime = 2f;
    [SerializeField] private GameObject toungeFrontObj;
    [SerializeField] private PlayerController enemy;
    [SerializeField] private float ikichi = 20f;
    private Coroutine toungeCoroutine = null;
    private Coroutine waitPushCorotuine = null;
    private Rigidbody2D toungeRigid;

    private float pushTime = 0f;
	// Use this for initialization
	void Start () {
        toungeRigid = toungeFrontObj.GetComponent<Rigidbody2D>();
        if(toungeRigid==null){
            Debug.LogError("舌オブジェクトにRigidbody2Dがアタッチされていません。");
        }
        }
	
	// Update is called once per frame
	void Update () {

        if (waitPushCorotuine != null||toungeCoroutine!=null) return;
        if (playerType == PlayerEnum.Player1)
        {
            if (Input.GetButtonDown("Tounge1"))
            {
                waitPushCorotuine = StartCoroutine(WaitPushCoroutine());
            }
        }
        else{
            if (Input.GetButtonDown("Tounge2"))
            {
                waitPushCorotuine = StartCoroutine(WaitPushCoroutine());
            }
        }

	}

    private IEnumerator WaitPushCoroutine(){
        pushTime = 0f;
        while(pushTime<=1f){
            if (playerType == PlayerEnum.Player1)
            {
                if (Input.GetButtonUp("Tounge1"))
                {
                    break;
                }
            }
            else
            {
                if (Input.GetButtonUp("Tounge2"))
                {
                    break;
                }
            }
            pushTime += Time.deltaTime;
            yield return null;
        }
        toungeCoroutine = StartCoroutine(ToungeCorotine());

        waitPushCorotuine = null;

    }

    private IEnumerator ToungeCorotine(){
        ResetTounge();
        Vector2 inputVec = Vector2.zero;
        bool isLeafTouch = false;
        toungeFrontObj.GetComponent<ToungeFront>().onHitLeafAction = () =>
        {
            isLeafTouch = true;
            toungeFrontObj.GetComponent<ToungeFront>().power = 2 + pushTime * 10f;
        };
        if (playerType == PlayerEnum.Player1)
        {
            inputVec = new Vector2(Input.GetAxis("Horizontal1"), -1f*Input.GetAxis("Vertical1"));
        }else{
            inputVec = new Vector2(Input.GetAxis("Horizontal2"), -1f*Input.GetAxis("Vertical2"));
        }

        if(inputVec==Vector2.zero){
            inputVec = this.GetComponent<Rigidbody2D>().velocity.normalized;
            if(inputVec==Vector2.zero){
                inputVec = Vector2.right;
            }

        }


        var normVec = (enemy.transform.position - this.transform.position).normalized;
        if(Vector2.Angle(normVec,inputVec)<ikichi){
            inputVec = normVec;
        }
        float time = 0f;
        while(time <=toungeTime&&!isLeafTouch){
            toungeRigid.transform.Translate(inputVec.normalized * toungeSpeed,Space.Self);
            yield return new  WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }

        toungeFrontObj.GetComponent<Collider2D>().isTrigger = true;
        while((this.transform.position-toungeFrontObj.transform.position).magnitude>0.1f){
            toungeRigid.transform.Translate(-1f*inputVec.normalized * toungeBackSpeed, Space.Self);
            yield return new WaitForFixedUpdate();
        }

        ResetTounge();
        toungeCoroutine = null;
    }

    private void ResetTounge()
    {
        toungeRigid.velocity = Vector2.zero;
        toungeFrontObj.transform.position = this.transform.position;
        toungeFrontObj.GetComponent<Collider2D>().isTrigger = false;
        toungeFrontObj.GetComponent<ToungeFront>().power = 2;
    }
}
