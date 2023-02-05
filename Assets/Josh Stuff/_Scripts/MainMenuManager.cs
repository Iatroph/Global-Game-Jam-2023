using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsPanel;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

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
        if(SceneManager.GetSceneByBuildIndex(1) != null)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ToggleCredits(bool toggle)
    {
        creditsPanel.SetActive(toggle);
    }

}
