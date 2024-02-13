using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogeScript : MonoBehaviour
{
    public AudioClip testAudio;
    [SerializeField] private GameObject audioSource;
    [SerializeField] private GameObject dialogeBox;
    [SerializeField] private TMP_Text dialogeText;
    [SerializeField] private TMP_Text nameText;
    private string[] currentText;
    private string[] currentNames;
    private AudioClip[] currentAudio;
    private int currentIndex = 0;
    private float timeTillNextDial;
    private float[] currentDialogeTimes;
    private GameObject currentSource;
    private GameObject sourceEmpty;
    // Start is called before the first frame update
    void Start()
    {
        if(dialogeBox == null)
        {
            dialogeBox = GameObject.Find("Dialoge");
        }
        if (dialogeText == null)
        {
            dialogeText = GameObject.Find("DialogeText").GetComponent<TMP_Text>();
        }
        if (nameText == null)
        {
            nameText = GameObject.Find("NameText").GetComponent<TMP_Text>();
        }
        if(sourceEmpty == null)
        {
            sourceEmpty = GameObject.Find("AudioSources");
        }
        PlayDialoge(new string[] {"Dia1","Dia2","Dia3","\"Test Audiok\"","Dia5","Dia6"},new string[] {"Name1","Name2","Name3","Name4","Name5","Name6"},new AudioClip[] {testAudio,testAudio,testAudio,testAudio,testAudio,testAudio}, new float[] {10f,10,10,10,10,10});
    }

    private void Update()
    {
        if (Input.GetButtonDown("SkipDialoge"))
        {
            Debug.Log("Skipped Dialoge");
            timeTillNextDial = -1;
            Destroy(currentSource);
        }
        timeTillNextDial -= Time.deltaTime;
        if (currentIndex < currentAudio.Length)
        {
            if (timeTillNextDial < 0)
            {
                PlayText(currentText[currentIndex], currentNames[currentIndex]);
                PlayVoiceline(currentAudio[currentIndex]);
                timeTillNextDial = currentDialogeTimes[currentIndex];
                currentIndex++;
            }
        }
        else
        {
            if (timeTillNextDial < 0)
            {
                dialogeBox.SetActive(false);
            }
        }
    }

    public void PlayDialoge(string[] text, string[] names, AudioClip[] audio, float[] dialogeTime)
    {
        currentIndex = 0;
        currentText = text;
        currentNames = names;
        currentAudio = audio;
        currentDialogeTimes = dialogeTime;
        dialogeBox.SetActive(true);
    }
    public void PlayText(string text,string name)
    {
        dialogeText.text = text;
        nameText.text = name;
    }
    public void PlayVoiceline(AudioClip audio)
    {
        if(audioSource != null)
        {
            AudioSource source = Instantiate(audioSource).GetComponent<AudioSource>();
            source.clip = audio;
            source.Play();
            source.gameObject.GetComponent<TimeKillScript>().currentTime = audio.length;
            currentSource = source.gameObject;
            currentSource.transform.parent = sourceEmpty.transform;
        }
    }
}
