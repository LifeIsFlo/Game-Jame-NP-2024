using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeScript : MonoBehaviour
{
    private AudioSource musicBlock;
    // Start is called before the first frame update
    void Start()
    {
        musicBlock = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    public void ChangeMusic(AudioClip musicClip)
    {
        musicBlock.clip = musicClip;
        musicBlock.Play();
    }
}
