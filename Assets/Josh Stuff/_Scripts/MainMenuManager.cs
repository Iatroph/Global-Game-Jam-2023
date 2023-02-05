using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
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

    public void ToggleCredits(bool toggle)
    {
        creditsPanel.SetActive(toggle);
    }

}
