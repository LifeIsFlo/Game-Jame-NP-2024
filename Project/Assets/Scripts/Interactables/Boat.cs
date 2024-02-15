using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {

    }

    public void Drop()
    {
        
    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        hasSomething = false;
    }

    public void Use()
    {
        
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
