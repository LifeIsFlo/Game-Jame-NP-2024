using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop()
    {
        this.AddComponent<Rigidbody>();
        GetComponent<BoxCollider>().enabled = true;
        enabled = false;
    }

    public void Use()
    {

    }

    public string GetName()
    {
        return "Cube";
    }

    public void PickUp()
    {
        GetComponent<BoxCollider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        enabled = true;
    }
}
