using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Axe : MonoBehaviour, IInteractable
{
    Rigidbody rb;

    public float maxDistance;

    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(-90,180,0);
        transform.localPosition = new Vector3(0,0,5);
    }

    public void Use()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.parent.parent.position, transform.parent.parent.forward, out hit, maxDistance, layer))
        {
            Debug.Log("hit");
            
            var tree = hit.transform.GetComponent<reparing>();
            if (tree)
            {
                if (tree.isTiming)
                {
                    tree.Hit();
                }
                else
                {
                    tree.Interact();
                }
            }
        }
    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        rb = GetComponent<Rigidbody>();
        transform.parent = hand;
        hasSomething = true;
        GetComponent<MeshCollider>().enabled = false;
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

    public string GetName()
    {
        return "axe";
    }

    public string GetInteraction()
    {
        return "pick up";
    }
}
