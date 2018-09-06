﻿using System.Collections;
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
            if (this.GetComponent<Collider2D>().isTrigger) return;
            if (r.tag == "Leaf" || r.tag == "Wall")
            {
                if(onHitLeafAction!=null)
                onHitLeafAction();
            }
            var layerName = LayerMask.LayerToName(r.gameObject.layer);
            if(layerName == "FrogA"||layerName=="FrogB"){
                if(r.gameObject.layer!=this.gameObject.layer){
                    
                    var rigid = r.gameObject.GetComponent<Rigidbody2D>();
                    rigid.AddForce((r.transform.position - this.transform.position).normalized*2f,ForceMode2D.Impulse);
                    var playerController = r.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.Impact();
                    }

                }
            }
        }
    }
   
}
