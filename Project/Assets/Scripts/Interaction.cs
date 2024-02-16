using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform player;
    public Transform hand;

    Transform current;
    Transform currentSee;

    public TMP_Text lookText;

    public float maxDistance;
    public float lookRayTime = .1f;

    public LayerMask pickUpAble;

    bool hasSomething;
    public bool sees;

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
        if (Input.GetButtonDown("Use") && hasSomething)
        {
            Use();
        }
        StartCoroutine(lookUI());
        lookUIinit();

        try
        {
            var child = hand.GetChild(0);
            if (child)
            {
                current = child;
                hasSomething = true;
            }
            else
            {
                current = null;
                hasSomething = false;
            }
        }
        catch
        {
            current = null;
            hasSomething = false;
        }
        
    }

    void lookUIinit()
    {
        if (!sees)
        {
            lookText.transform.parent.gameObject.SetActive(false);
        }
        else if(!hasSomething)
        {
            if(currentSee != null)
            {
                if (currentSee.GetComponent<Boat>() == null && currentSee.GetComponent<IInteractable>() != null)
                {
                    lookText.text = $"Press E to {currentSee.GetComponent<IInteractable>().GetInteraction()} {currentSee.GetComponent<IInteractable>().GetName()}";
                    lookText.transform.parent.gameObject.SetActive(true);
                }
            }
        }
    }

    void Use()
    {
        if (current)
        {
            current.GetComponent<IInteractable>().Use();
        }
    }

    IEnumerator lookUI()
    {
        yield return new WaitForSeconds(lookRayTime);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpAble))
        {
            currentSee = hit.transform;
            sees = true;
        }
        else
        {
            currentSee = null;
            sees = false;
        }
    }

    void PickUp()
    {
        if (!hasSomething)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpAble))
            {
                bool canPick;
                hit.transform.GetComponent<IInteractable>().Interact(hand, out canPick);
                Debug.Log("pickup");
            }
        }
        else
        {
            current.GetComponent<IInteractable>().Drop();
        }
    }
}
