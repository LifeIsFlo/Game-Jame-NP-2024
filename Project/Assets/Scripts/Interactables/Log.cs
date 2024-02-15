using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Drop()
    {

    }

    public void Use()
    {

    }

    public void Interact(Transform hand)
    {
        transform.parent = hand;
        GetComponent<BoxCollider>().enabled = false;
        enabled = true;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Destroy(rb);
    }

    public string GetName()
    {
        return "Log";
    }

    public string GetInteraction()
    {
        return "pick up";
    }
}
