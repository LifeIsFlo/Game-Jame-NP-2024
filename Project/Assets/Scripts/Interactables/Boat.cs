using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour, IInteractable
{
    public float woodLeft;
    public GameObject boatFix;
    [SerializeField] private AudioClip[] boatFixClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(woodLeft <= 0)
        {
            BoatFixed();
        }
    }

    public void Drop()
    {
        
    }

    public void BoatFixed()
    {
        Destroy(gameObject);
        boatFix.SetActive(true);
        FindAnyObjectByType<DialogeScript>().PlayDialoge(new string[] { "Thank you for fixing my boat! I can now continue my travels." }, new string[] {"Theseus" }, boatFixClips,new float[] { boatFixClips[0].length });
    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        hasSomething = false;
        if(hand.GetChild(0) != null)
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
