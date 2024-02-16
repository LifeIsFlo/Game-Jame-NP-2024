using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class DialogeScript : MonoBehaviour
{
    public AudioClip theseusDia;
    public AudioClip sandDia;
    public AudioClip[] rapDia;
    //Objects n stuff
    [SerializeField] private GameObject audioSource;
    [SerializeField] private GameObject dialogeBox;
    [SerializeField] private TMP_Text dialogeText;
    [SerializeField] private TMP_Text nameText;

    //Doing the dialoge stuffs
    private string[] currentText;
    private string[] currentNames;
    private AudioClip[] currentAudio;
    private int currentIndex = 0;
    private float timeTillNextDial;
    private float[] currentDialogeTimes;
    private GameObject currentSource;
    private GameObject sourceEmpty;
    private bool canSkip;


    void Awake()
    {
        //Adds some objects if they dont exist
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
        //Turns the dialoge box off because otherwise it cant find it
        //

        //This how you call these things

        //PlayDialoge(new string[] {"Dia1","Dia2","Dia3","\"Test Audiok\"","Dia5","Dia6"},new string[] {"Name1","Name2","Name3","Name4","Name5","Name6"},new AudioClip[] {testAudio,null,testAudio,testAudio,testAudio,testAudio}, new float[] {30f,10,10,10,10,10});
        //PlayDialoge(new string[] {null, null, "Wait! You down there! Stranger! Could you do me a favor and find my comb for me?\r\nIm going to need it to keep my hair from being tangled.\r\nit should be somewhere down there.", "Oh thank Goodness! You found my comb! Now i can untangle my hair again.", null, null }, new string[] { "Name1", "Name2", "Rapunzel", "Rapunzel", "Name5", "Name6" }, testClips, new float[] { 0.5f, 25f, 10, 5f, 7.5f, 0.5f });
        //PlayVoiceline(testAudio,true);
    }
    private void Start()
    {
        dialogeBox.SetActive(false);
    }

    private void Update()
    {
        //Skip dialoge
        if (Input.GetButtonDown("SkipDialoge") && dialogeText.text != "")
        {
            Debug.Log("Skipped Dialoge");
            SkipDialoge();
        }

        //Otherwise you will get an error if you dont have any dialoge
        if (currentAudio != null)
        {
            timeTillNextDial -= Time.deltaTime;
            //Does an array of dialoges
            if (currentIndex < currentAudio.Length)
            {
                
                if (timeTillNextDial < 0)
                {
                    SkipDialoge();
                    PlayText(currentText[currentIndex], currentNames[currentIndex]);
                    if (currentAudio[currentIndex] != null)
                    {
                        PlayVoiceline(currentAudio[currentIndex], true);
                    }
                    timeTillNextDial = currentDialogeTimes[currentIndex];
                    currentIndex++;
                }
            }
            else
            {
                //Turns off the dialoge box if dialoge is done
                if (timeTillNextDial < 0)
                {
                    dialogeBox.SetActive(false);
                }
            }
        }
    }

    public void PlayDialoge(string[] text, string[] names, AudioClip[] audio, float[] dialogeTime)
    {
        //Basically sets all the values
        currentIndex = 0;
        currentText = text;
        currentNames = names;
        currentAudio = audio;
        currentDialogeTimes = dialogeTime;
        if (text[0] != null)
        {
            dialogeBox.SetActive(true);
        }
    }

    public void PlayText(string text,string name)
    {
        //Sets the text
        if(text != null)
        {
            dialogeBox.SetActive(true);
            dialogeText.text = text;
            nameText.text = name;
        }
        else
        {
            dialogeBox.SetActive(false);
            dialogeText.text = "";
            nameText.text = "";
        }
    }
    public void PlayVoiceline(AudioClip audio,bool skippable)
    {
        //Spawns an audio source and makes it play stuff
        if(audioSource != null)
        {
            AudioSource source = Instantiate(audioSource).GetComponent<AudioSource>();
            source.clip = audio;
            source.Play();
            source.gameObject.GetComponent<TimeKillScript>().currentTime = audio.length;
            currentSource = source.gameObject;
            currentSource.transform.parent = sourceEmpty.transform;
            canSkip = skippable;
        }
    }
    public void SkipDialoge()
    {
        if (canSkip)
        {
            timeTillNextDial = -1;
            Destroy(currentSource);
        }
    }

    public void TheseusStart()
    {
        //        PlayDialoge(new string[] { null }, new string[] { null }, new AudioClip[] { null }, new float[] { null });
        PlayDialoge(new string[] { null }, new string[] { null }, new AudioClip[] { theseusDia }, new float[] { theseusDia.length });
    }

    public void SandStart()
    {
        PlayDialoge(new string[] { null }, new string[] { null }, new AudioClip[] { sandDia}, new float[] { sandDia.length });
    }

    public void RapStart()
    {
        PlayDialoge(new string[] { null, "Wait! You down there! Stranger! Could you do me a favor and find my comb for me?\r\nIm going to need it to keep my hair from being tangled.\r\nit should be somewhere down there.","Find the comb and then press 'LMB' on the hair at the tower"}, new string[] {"", "Rapunzel","New quest"}, rapDia, new float[] { rapDia[0].length, rapDia[1].length,10f });
    }
}
