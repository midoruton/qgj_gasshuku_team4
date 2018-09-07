using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ToungeFront : MonoBehaviour {

    public Action onHitLeafAction;
    public float basePower;
    public float bonusPower;
    public float chargeTimeNormarized;
    public Transform parentTransform;
    private Coroutine timeScaleCoroutine;
    private void FixedUpdate()
    {
        var result = new Collider2D[10];
        GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(),result);
        foreach(var r in result){
            if (r == null) return;
            if (this.GetComponent<Collider2D>().isTrigger) return;
            if (r.tag == "Leaf" || r.tag == "Wall")
            {
                if(onHitLeafAction!=null)
                onHitLeafAction();
            }
            var layerName = LayerMask.LayerToName(r.gameObject.layer);
            if(layerName == "FrogA"||layerName=="FrogB"){
                if(r.gameObject.layer!=this.gameObject.layer){

                    if (onHitLeafAction != null)onHitLeafAction();
                    var rigid = r.gameObject.GetComponent<Rigidbody2D>();
                    rigid.AddForce((r.transform.position - parentTransform.position).normalized*(basePower+bonusPower*chargeTimeNormarized),ForceMode2D.Impulse);
                    var playerController = r.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.Impact(chargeTimeNormarized*1.3f);
                        if (timeScaleCoroutine == null) StartCoroutine(TimeScale());
                    }


                }
            }
        }
    }

    IEnumerator TimeScale(){
        Time.timeScale = 0.0f;
        if (chargeTimeNormarized > 0.8f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 1f;
        timeScaleCoroutine = null;
    }
   
}
