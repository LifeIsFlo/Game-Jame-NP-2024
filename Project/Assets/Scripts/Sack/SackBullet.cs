using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 10f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
