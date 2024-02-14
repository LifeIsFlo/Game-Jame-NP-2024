
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class reparing : MonoBehaviour
{
    public GameObject tree;
    public GameObject log;

    public Canvas canvas;
    public TMP_Text text;
    public Slider slider;
    [SerializeField] private float decreaseRate = 0.005f;
    [SerializeField] private int minPercentage = 40;
    [SerializeField] private int maxPercentage = 60;
    public float treelife = 5;
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
                slider.value -= decreaseRate / Time.deltaTime;
            }
            if (left == true)
            {
                slider.value += decreaseRate / Time.deltaTime;
            }



            if (slider.value > ((slider.maxValue - slider.minValue) / 100f) * minPercentage && slider.value < ((slider.maxValue - slider.minValue) / 100f) * maxPercentage)
            {
                text.gameObject.SetActive(true);
            }

            //cheat 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                treelife -= 5f;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                treelife -= 1f;
                Debug.Log("Hit!");
            }
                if (treelife == 0)
                {
                Instantiate(tree, transform.position, Quaternion.identity);
                Instantiate(log, transform.position, Quaternion.identity);

                Destroy(tree);
                canvas.gameObject.SetActive(false);
                    text.gameObject.SetActive(false);
                    isTiming = false;
                    Debug.Log("Slider op nul!");
                    treelife += 5f;
                }
            
        }
        if (slider.value > slider.minValue && slider.value < ((slider.maxValue - slider.minValue) / 100f) * minPercentage)
        {
            text.gameObject.SetActive(false);
        }
        if (slider.value > ((slider.maxValue - slider.minValue) / 100f) * maxPercentage && slider.value < slider.maxValue)
        {
            text.gameObject.SetActive(false);
        }


    }
}