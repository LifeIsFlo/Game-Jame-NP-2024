using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Log : MonoBehaviour, IInteractable
{
    Rigidbody rb;

    bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            transform.localPosition = new Vector3(0,-3,7.5f);
            transform.localRotation = Quaternion.Euler(-20, 90, 0);
        }
    }

    private void OnEnable()
    {

    }

    public void Drop()
    {
        transform.parent = null;
        this.AddComponent<Rigidbody>();
        GetComponent<MeshCollider>().enabled = true;
        enabled = false;
    }

    public void Use()
    {

    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("lol");
        enabled = true;
        transform.parent = hand;
        pickedUp = true;
        GetComponent<MeshCollider>().enabled = false;
        Destroy(rb);
        hasSomething = true;
        transform.localRotation = Quaternion.Euler(0, 90, 90);
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
