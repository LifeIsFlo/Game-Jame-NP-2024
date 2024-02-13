using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform player;

    public Transform hand;

    Transform current;

    public float maxDistance;
    public LayerMask pickUpAble;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PickUp"))
        {
            PickUp();
        }
        if (Input.GetButtonDown("Use"))
        {
            Use();
        }
    }

    void Use()
    {
        if (current)
        {
            current.GetComponent<IInteractable>().Use();
        }
    }

    void PickUp()
    {
        foreach (Transform t in hand)
        {
            t.parent = null;
            current = null;
            t.GetComponent<IInteractable>().Drop();
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpAble))
        {
            hit.transform.parent = hand;
            hit.transform.GetComponent<IInteractable>().PickUp();
            current = hit.transform;
            Debug.Log("pickup");
        }
    }
}
