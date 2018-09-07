using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winfalse : MonoBehaviour {

    public GameObject FrogAWin;
    public GameObject FrogBWin;
    private int _frogACount;
    private int _frogBCount;

	// Use this for initialization
	void Start ()
    {
        _frogACount = ResultCounter.GetFrogAResult();
        _frogBCount = ResultCounter.GetFrogBResult();

        if(_frogACount > _frogBCount)
        {
            Instantiate(FrogAWin, transform.position, transform.rotation);
        }
        else if(_frogACount < _frogBCount)
        {
            Instantiate(FrogBWin, transform.position, transform.rotation);
        }
        else
        {
            if(Random.Range(0, 2) == 0)
            {
                Instantiate(FrogAWin, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(FrogBWin, transform.position, transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
