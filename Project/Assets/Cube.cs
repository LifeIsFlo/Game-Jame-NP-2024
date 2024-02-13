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
        enabled = false;
    }

    public void Use()
    {

    }

    public void PickUp()
    {
        Destroy(GetComponent<Rigidbody>());
        enabled = true;
    }
}
