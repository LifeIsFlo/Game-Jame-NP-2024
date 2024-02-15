using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Renderer item in GetComponentsInChildren<Renderer>())
        {
            item.rendererPriority = 0;
        }
    }
}
