using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed = 1;
    public bool cameraMoves = true;
    private float rotationX = 0.0f;
    bool spins = false;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

        //Remove Before Launch!!!!!
        if (Input.GetKeyDown(KeyCode.I))
        {
            spins = !spins;
        }
        if (spins)
        {
            transform.eulerAngles = new Vector3(rotationX, transform.rotation.eulerAngles.y + 1, 0);
        }
        //Actual Code:
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (cameraMoves == true)
            {
                cameraMoves = false;
            }
            else
            {
                cameraMoves = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraMoves == true)
            {
                Cursor.visible = true;
                cameraMoves = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                cameraMoves = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (cameraMoves == true)
        {
            player.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);
            rotationX -= rotationSpeed * Input.GetAxis("Mouse Y");
            rotationX = Mathf.Clamp(rotationX, -70, 70);
            transform.eulerAngles = new Vector3(rotationX, transform.rotation.eulerAngles.y, 0);
        }
    }

    public void ChangeSensitivity(float value)
    {
        rotationSpeed = value;
    }
}
