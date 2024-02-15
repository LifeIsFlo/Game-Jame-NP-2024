using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Comb : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    public bool spinning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;

        if (spinning)
        {
            transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, new Vector3(0, 360, 0), .05f));
        }

        if(Vector3.Distance(transform.localRotation.eulerAngles, new Vector3(0, 360, 0)) < 1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            spinning = false;
        }
    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        transform.parent = hand;
        hasSomething = true;
        GetComponent<BoxCollider>().enabled = false;
        enabled = true;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Destroy(rb);
    }

    public void Drop()
    {
        transform.parent = null;
        this.AddComponent<Rigidbody>();
        enabled = false;
    }

    public void Use()
    {
        spinning = true;
    }

    public string GetName()
    {
        return "Comb";
    }

    public string GetInteraction()
    {
        return "pick up";
    }
}
