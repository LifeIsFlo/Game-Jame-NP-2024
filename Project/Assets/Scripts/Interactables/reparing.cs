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
    bool canChop;
    public bool isTiming = false;
    private bool left = true;
    bool shouldHit;
    void Start()
    {      
        canChop = true;
    }

    // IInteractable stuff

    public void Interact()
    {
        if (!isTiming && canChop)
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
        if (isTiming && Time.timeScale != 0)
        {
            text.text = "Click!!";
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
                Debug.Log("R" + decreaseRate / Time.deltaTime * speed);
                slider.value -= decreaseRate / Time.deltaTime * speed;
            }
            if (left == true)
            {
                Debug.Log("L" + decreaseRate / Time.deltaTime * speed);
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
    }

    IEnumerator StopMiniGame()
    {
        text.gameObject.SetActive(true);
        text.text = "FAIL!";
        yield return new WaitForSeconds(1.5f);
        canvas.gameObject.SetActive(false);
        canChop = true;
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
            canChop = false;
            StartCoroutine(StopMiniGame());
        }
    }
}