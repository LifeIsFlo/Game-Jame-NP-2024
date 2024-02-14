using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mix;
    private string volName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        mix.SetFloat(volName, Mathf.Log10(volume) * 20);
    }

    public void SetVolumeName(string name)
    {
        volName = name;
    }
}
