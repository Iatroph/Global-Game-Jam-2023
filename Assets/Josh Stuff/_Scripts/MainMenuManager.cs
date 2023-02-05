using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        if(SceneManager.GetSceneAt(1) != null)
        {
            SceneManager.LoadScene(1);
        }
    }

}
