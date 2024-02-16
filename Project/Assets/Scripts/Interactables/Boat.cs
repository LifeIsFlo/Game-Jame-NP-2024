using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour, IInteractable
{
    public float woodLeft;
    public GameObject boatFix;
    [SerializeField] private AudioClip[] boatFixClips;
    bool finished = false;
    [SerializeField] private GameObject entireBoatScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(woodLeft <= 0 && !finished)
        {
            StartCoroutine(BoatFixed());
        }
    }

    public void Drop()
    {
        
    }

    IEnumerator BoatFixed()
    {
        if (!finished)
        {
            finished = true;
            Debug.Log("FixBoat");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            boatFix.SetActive(true);
            FindAnyObjectByType<DialogeScript>().PlayDialoge(new string[] { "Thank you for fixing my boat! I can now continue my travels." }, new string[] { "Theseus" }, boatFixClips, new float[] { boatFixClips[0].length });
            yield return new WaitForSeconds(boatFixClips[0].length);
            FindAnyObjectByType<levelui>().ToggleLevelSelect();
            FindAnyObjectByType<levelui>().ToggleLevelSelect();
            entireBoatScene.SetActive(false);
            FindAnyObjectByType<MusicChangeScript>().ChangeMusic();
            Destroy(gameObject, 10);
        }
    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        hasSomething = false;
        if(hand.GetChild(0) != null || hand.GetChild(0).tag != "Axe")
        {
            AddLog();
        }
    }

    public void Use()
    {
        
    }

    public void AddLog()
    {
        woodLeft--;
    }

    public string GetName()
    {
        return "boat";
    }

    public string GetInteraction()
    {
        return "put down log in";
    }
}
