using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sack : MonoBehaviour, IInteractable
{
    public Transform cam;

    public float throwForce;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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
    }

    public void PickUp()
    {
        Destroy(rb);
    }

    public void Use()
    {
        rb.AddForce(cam.forward * throwForce);
    }

    public string GetName()
    {
        return "Bag";
    }
}
