using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 2);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Rigidbody>());
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
