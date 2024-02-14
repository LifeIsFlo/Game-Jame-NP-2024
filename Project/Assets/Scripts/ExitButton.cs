using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExitButton : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioMixerGroup group;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        if (audioSource != null)
        {
            FindObjectOfType<PauseManager>().canPause = false;
            AudioSource source = Instantiate(audioSource).GetComponent<AudioSource>();
            source.clip = closeSound;
            source.outputAudioMixerGroup = group;
            source.Play();
            source.gameObject.GetComponent<TimeKillScript>().currentTime = closeSound.length;
        }
        Time.timeScale = 1;
        StartCoroutine("WaitQuit");
    }

    private IEnumerator WaitQuit()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
        Debug.Log("Quit");
    }
}
