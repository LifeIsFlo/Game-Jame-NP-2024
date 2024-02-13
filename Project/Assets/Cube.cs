using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Cube : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        transform.parent = null;
        this.AddComponent<Rigidbody>();
        GetComponent<BoxCollider>().enabled = true;
        enabled = false;
    }

    public void Use()
    {

    }

    public string GetName()
    {
        return "Cube";
    }

    public void PickUp()
    {
        GetComponent<BoxCollider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        enabled = true;
    }
}
