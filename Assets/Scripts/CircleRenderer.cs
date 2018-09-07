using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour {
    [Range(0,50)]
    public int segments = 50;
    [Range(0,5)]
    public float xradius = 5;
    [Range(0,5)]
    public float yradius = 5;
    LineRenderer line;

    private void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        CreatePoints();
        
    }
    void Start ()
    {
    }

    void CreatePoints ()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition (i,new Vector2(x,z) );

            angle += (360f / segments);
        }
    }

    public void ResetPoints(){
        if (line != null)
        {
            line.positionCount = 0;
            line.positionCount = segments + 1;
        }
    }
    private void FixedUpdate()
    {
        CreatePoints();
    }
}
