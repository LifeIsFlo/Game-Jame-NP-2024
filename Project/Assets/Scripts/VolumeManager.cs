using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mix;
    private string volName;
    public void SetVolume(float volume)
    {
        mix.SetFloat(volName, Mathf.Log10(volume) * 20);
    }

    public void SetVolumeName(string name)
    {
        volName = name;
    }
}
