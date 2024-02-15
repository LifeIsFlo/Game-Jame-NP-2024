using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class reparing : MonoBehaviour
{
    public GameObject log;
    public float speed;
    public Canvas canvas;
    public TMP_Text text;
    public Slider slider;
    bool everStarted;
    [SerializeField] private float decreaseRate = 0.005f;
    [SerializeField] private int minPercentage = 40;
    [SerializeField] private int maxPercentage = 60;
    public float treelife = 5;
    public bool isTiming = false;
    private bool left = true;
    bool shouldHit;
    void Start()
    {      
    }

    // IInteractable stuff

    public void Interact()
    {
        if (!isTiming)
        {
            everStarted = true;
            isTiming = true;
            canvas.gameObject.SetActive(true);
            slider.value = slider.maxValue;
        }
    }

    // Damian stuff
    void Update()
    {
        if (isTiming)
        {
            if (slider.value == slider.maxValue)
            {
                left = false;
            }
            if (slider.value == slider.minValue)
            {
                left = true;
            }
            if (left == false)
            {
                slider.value -= decreaseRate / Time.deltaTime * speed;
            }
            if (left == true)
            {
                slider.value += decreaseRate / Time.deltaTime * speed;
            }



            if (slider.value > ((slider.maxValue - slider.minValue) / 100f) * minPercentage && slider.value < ((slider.maxValue - slider.minValue) / 100f) * maxPercentage)
            {
                text.gameObject.SetActive(true);
                shouldHit = true;
            }
            else
            {
                text.gameObject.SetActive (false);
                shouldHit = false;
            }
            if (treelife == 0)
            {
                Instantiate(log, transform.position + log.transform.position, log.transform.rotation);

                Destroy(gameObject);
            }
        }
        else if(everStarted)
        {
            StartCoroutine(StopMiniGame());
        }
    }

    IEnumerator StopMiniGame()
    {
        text.gameObject.SetActive(true);
        text.text = "FAIL!";

        yield return new WaitForSeconds(2);
        canvas.gameObject.SetActive(false);
    }

    public void Hit()
    {
        Debug.Log("Hit!");

        if (shouldHit)
        {
            treelife -= 1f;
        }
        else
        {
            isTiming = false;
            treelife = 5f;
        }
    }
}