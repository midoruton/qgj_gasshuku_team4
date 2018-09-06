using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    public string targetSceneName;

    public void Run()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }
}
