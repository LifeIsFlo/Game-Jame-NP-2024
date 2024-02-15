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
    }

    void lookUIinit()
    {
        if (!sees)
        {
            lookText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            lookText.text = $"Press E to {currentSee.GetComponent<IInteractable>().GetInteraction()} {currentSee.GetComponent<IInteractable>().GetName()}";
            lookText.transform.parent.gameObject.SetActive(true);
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, pickUpAble))
        {
            bool canPick;
            hit.transform.GetComponent<IInteractable>().Interact(hand, out canPick);
            if (!hasSomething && canPick)
            {
                current = hit.transform;
            }
            Debug.Log("pickup");
        }
    }
}
