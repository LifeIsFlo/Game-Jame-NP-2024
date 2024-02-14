using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKillScript : MonoBehaviour
{
    public float currentTime = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
