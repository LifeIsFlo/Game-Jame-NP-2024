using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Sack : MonoBehaviour, IInteractable
{
    public float coolDown;
    float elapsedCoolDown;
    bool coolStarted;

    Transform cam;

    public GameObject sack;

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

    private void OnEnable()
    {
        cam = transform.parent.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = Vector3.zero;
        if (coolStarted)
        {
            elapsedCoolDown += Time.deltaTime;
        }

        if(elapsedCoolDown >= coolDown)
        {
            coolStarted = false;
            elapsedCoolDown = 0;
        }
    }

    public void Drop()
    {
        
    }

    public void Interact(Transform hand)
    {
        transform.parent = hand;
        GetComponent<BoxCollider>().enabled = false;
        enabled = true;
        Destroy(rb);
    }

    public void Use()
    {
        if (!coolStarted)
        {
            var newSack = Instantiate(sack, cam.position + cam.forward, Quaternion.Euler(-90, 0, 0));
            newSack.transform.parent = null;
            newSack.AddComponent<Rigidbody>();
            newSack.GetComponent<BoxCollider>().enabled = true;
            rb = newSack.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce); 

            coolStarted = true;
        }
    }
    public string GetName()
    {
        return "Bag";
    }

    public string GetInteraction()
    {
        return "pick up";
    }
}
