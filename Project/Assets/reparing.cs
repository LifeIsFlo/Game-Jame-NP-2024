using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class reparing : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public Slider slider;
    private float decreaseRate = 0.005f;

    private float treelife = 5;

    private bool isTiming = false;
    private bool left = true;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            canvas.gameObject.SetActive(true);
            isTiming = true;
            slider.value = slider.maxValue;
            treelife = 5f;
        }

        if (isTiming)

        {
            if (slider.value == 100f)
            {
                left = false;
            }
            if (slider.value == 0)
            {
                left = true;
            }
            if (left == false)
            {
                slider.value -= decreaseRate / Time.deltaTime;
            }
            if (left == true)
            {
                slider.value += decreaseRate / Time.deltaTime;
            }



            if (slider.value > 40f && slider.value < 60f)
            {
                text.gameObject.SetActive(true);

                if (Input.GetKeyUp(KeyCode.E))
                {
                    treelife -= 1f;


                    if (treelife ==0)
                    {
                        canvas.gameObject.SetActive(false);
                        text.gameObject.SetActive(false);
                        isTiming = false;
                        Debug.Log("Slider op nul!");
                    }
                }
            }
            if (slider.value > slider.minValue && slider.value < 40f)
            {
                text.gameObject.SetActive(false);
            }
            if (slider.value > 60f && slider.value < slider.maxValue)
            {
                text.gameObject.SetActive(false);
            }


        }
    }
}