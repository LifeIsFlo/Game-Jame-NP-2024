using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
        }
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PauseKey"))
        {
            Debug.Log("Paused");
            if (isPaused)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            FindObjectOfType<CameraMovement>().cameraMoves = isPaused;
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
        }
    }
}
