using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ToungeFront : MonoBehaviour {

    public Action onHitLeafAction;

    private void Update()
    {
        var result = new Collider2D[10];
        GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(),result);
        foreach(var r in result){
            if (r == null) return;
            if(r.tag == "Leaf"||r.tag=="Wall"){
                onHitLeafAction();
            }
        }
    }
   
}
