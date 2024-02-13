using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform player;

    public TMP_Text lookText;

    public bool sees;

    public Transform hand;

    public float lookRayTime = .1f;

    Transform current;

    public float maxDistance;
    public LayerMask pickUpAble;

    string currentName;

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
            lookText.text = $"Press E to pick up {currentName}";
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
            currentName = hit.transform.GetComponent<IInteractable>().GetName();
            sees = true;
        }
        else
        {
            sees = false;
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
