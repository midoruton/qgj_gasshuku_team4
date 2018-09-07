using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public GameObject eventSystemObj;
    public string targetSceneName;
    private UnityEngine.EventSystems.EventSystem ES;
    private bool evoked = false;
    private float t = 0;

    private void Start()
    {
        ES = eventSystemObj.GetComponent<UnityEngine.EventSystems.EventSystem>();
    }

    private void Update()
    {
        if (evoked)
        {
            t += Time.deltaTime;
            if (t > 0.5)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
            }
        }
    }

    public void Run()
    {
        ES.enabled = false;
        evoked = true;
    }
}
