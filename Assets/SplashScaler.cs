using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScaler : MonoBehaviour {
    [SerializeField] private float DestoryTime = 1f;
    [SerializeField]private AnimationCurve animationCurve;
    private void OnEnable()
    {
        
        Invoke("DestroyThis", DestoryTime);
    }


    void DestroyThis(){
        Destroy(this.gameObject);
    }


}
