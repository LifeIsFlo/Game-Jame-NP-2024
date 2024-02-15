using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject audioSourceEmpty;
    private bool isPaused = false;
    public bool canPause = true;
    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
        }
        if(audioSourceEmpty == null)
        {
            audioSourceEmpty = GameObject.Find("AudioSources");
        }
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PauseKey") && canPause)
        {
            Pause();
        }
    }
    public void Pause()
    {
        Debug.Log("Paused");
        if (isPaused)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            for (int i = 0; i < audioSourceEmpty.transform.childCount; i++)
            {
                audioSourceEmpty.transform.GetChild(i).GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            for (int i = 0; i < audioSourceEmpty.transform.childCount; i++)
            {
                audioSourceEmpty.transform.GetChild(i).GetComponent<AudioSource>().Pause();
            }
        }
        if (FindObjectOfType<CameraMovement>() != null)
        {
            FindObjectOfType<CameraMovement>().cameraMoves = isPaused;
        }
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
    }
}
