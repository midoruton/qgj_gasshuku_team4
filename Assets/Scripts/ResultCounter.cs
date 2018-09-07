using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCounter : MonoBehaviour {

    public static int FrogAResult;
    public GameObject FrogA;
    public static int FrogBResult;
    public GameObject FrogB;

    public static int GetFrogAResult()
    {
        return FrogAResult;
    }

    public static int GetFrogBResult()
    {
        return FrogBResult;
    }

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        FrogAResult = FrogA.GetComponent<PlayerHitpoint>().DeathCounter;
        FrogBResult = FrogB.GetComponent<PlayerHitpoint>().DeathCounter;
	}
}
