using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Comb : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    public bool spinning;
    [SerializeField]
    LayerMask luier;
    public GameObject EndComb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
    }

    void Start()
    {
        
    }
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
        GetComponent<Collider>().enabled = false;
        enabled = true;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Destroy(rb);
    }

    public void Drop()
    {
        transform.parent = null;
        this.AddComponent<Rigidbody>();
        GetComponent<Collider>().enabled = true;
        enabled = false;
    }

    public void Use()
    {
        spinning = true;
        RaycastHit hit;// als je een interact met comb doet op haar
        if (Physics.Raycast(transform.parent.parent.position, transform.parent.parent.forward, out hit, 20, luier))
        {
            var boat = hit.transform.GetComponent<Hair>();
            if (boat)
            {
                //dia shit
                EndComb.SetActive(true);
                Destroy(gameObject);
            }
        }
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
