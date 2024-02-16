using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hair : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    public GameObject EndComb;
    public bool hasSomethingg;

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

    }

    public void Interact(Transform hand, out bool hasSomething)
    {
        hasSomething = false;
        if (hand.GetChild(0) != null || hand.GetChild(0).tag != "Axe")
        {
            hasSomethingg = true;
            EndComb.SetActive(true);
            //print("wel item in hand");
            StartEindDia();
        }
    }

    public void StartEindDia() 
    {

    }

    public void StartBeginDia()
    {
        Debug.Log("StartQuest");
    }


    

    public void Drop()
    {
    }

    public void Use()
    {
    }

    public string GetName()
    {
        return "Comb";
    }



    public string GetInteraction()
    {
        return   hasSomethingg?  "True"  : "Press 'E' to pull hair";
    }
}
