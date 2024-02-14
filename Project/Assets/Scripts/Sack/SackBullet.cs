using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackBullet : MonoBehaviour
{
    public ChildSleep child;

    private void OnEnable()
    {
        Destroy(gameObject, 10f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 2);

        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Rigidbody>());
        transform.GetChild(0).gameObject.SetActive(true);

        if (child)
        {
            child.ShowZZZZZZZZ();
        }
    }
}
