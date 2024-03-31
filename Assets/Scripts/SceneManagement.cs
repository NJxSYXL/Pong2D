using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
	
    public void ChangeScene (string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
	
    public void QuitApp()
    {
        Application.Quit();
    }
}