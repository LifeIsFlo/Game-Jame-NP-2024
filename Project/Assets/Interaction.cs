using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject brush;

    Transform player;
    Transform hand;

    public float maxDistance;
    public LayerMask pickUpAble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("PickUp"))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpAble))
        {
            
        }
    }
}
