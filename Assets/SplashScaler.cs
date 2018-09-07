using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScaler : MonoBehaviour {
    private float defaultScale;
    private int step;
    [SerializeField]private AnimationCurve animationCurve;
    private void OnEnable()
    {
        defaultScale = this.transform.localScale.y;
        step = 0;
        Invoke("DestroyThis", 1f);
    }


    void DestroyThis(){
        Destroy(this.gameObject);
    }


}
