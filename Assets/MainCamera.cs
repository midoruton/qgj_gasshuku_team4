using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    [SerializeField] private Transform FrogA;
    [SerializeField] private Transform FrogB;
    [SerializeField] private float z_rate;
    [SerializeField] private float z_base;
	// Use this for initialization
	void Start () {
        Update();
	}
	
	// Update is called once per frame
	void Update () {
        var Tox = (FrogA.position.x + FrogB.position.x) / 2f;
        var Toy = (FrogA.position.y + FrogB.position.y) / 2f;
        var Toz = z_base + (FrogA.position - FrogB.position).magnitude * z_rate;
        this.transform.position = Vector3.Slerp (this.transform.position,new Vector3(Tox, Toy, Toz),0.05f);
	}
}
