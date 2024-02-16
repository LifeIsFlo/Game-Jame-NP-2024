using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour, IInteractable
{
    Rigidbody rb;

    public float lookRayTime = .1f;
    public bool sees;
    Transform currentSee;
    public GameObject canvas;
    public TMP_Text text;

    public LayerMask layer;
    public float maxDistance;

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

        StartCoroutine(lookUI());
        lookUIinit();
    }

    private void OnEnable()
    {
        canvas = GameObject.Find("PickUp");
        text = canvas.GetComponentInChildren<TMP_Text>();
    }

    void lookUIinit()
    {
        if (!sees)
        {
            canvas.SetActive(false);
        }
        else
        {
            text.text = $"Press LMB to {currentSee.GetComponent<IInteractable>().GetInteraction()} {currentSee.GetComponent<IInteractable>().GetName()}";
            canvas.SetActive(true);
        }
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
        RaycastHit hit;
        if(Physics.Raycast(transform.parent.parent.position, transform.parent.parent.forward, out hit, maxDistance, layer))
        {
            var boat = hit.transform.GetComponent<Boat>();
            if (boat)
            {
                boat.AddLog();
                canvas.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator lookUI()
    {
        yield return new WaitForSeconds(lookRayTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.parent.position, transform.parent.parent.forward, out hit, maxDistance, layer))
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
