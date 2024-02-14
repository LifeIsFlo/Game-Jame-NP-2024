using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSleep : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        var com = other.gameObject.GetComponentInChildren<SackBullet>();

        if (com)
        {
            com.child = this;
        }
    }

    public void ShowZZZZZZZZ()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
