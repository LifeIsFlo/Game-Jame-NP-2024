using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform item in transform)
        {
            item.localRotation = Quaternion.Euler(Vector3.zero);
            item.localPosition = Vector3.zero;
        }
    }
}
