using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public GameObject pauseCanvas;
    bool isGamePaused = false;
    [HideInInspector]
    public bool canPause = true;

    public bool canUseMouse = true;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else if (isGamePaused)
            {
                UnPauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        canUseMouse= false;

    }

    public void UnPauseGame()
    {
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        canUseMouse = true;

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
