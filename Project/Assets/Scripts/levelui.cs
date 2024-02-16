using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class levelui : MonoBehaviour
{
    public GameObject hub;
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public Button level1;
    public Button level2;
    public Button level3;
    public Canvas levelselect;
   private bool isLevelSelectActive = false;
    private bool lvl1done =false;
    private bool lvl2done = false;
    private bool lvl3done =true;
    
    void Start()
    {
        ToggleLevelSelect();
        level2.gameObject.SetActive(false);
        level3.gameObject.SetActive(false);
    }

    void Update()
    {
        //reset de level lock 
        if (Input.GetKeyDown(KeyCode.U))
        {
            lvl1done = false; lvl2done = true; lvl3done = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ToggleLevelSelect();
        }
        if(lvl1done == true)
        {
            level2.gameObject.SetActive(true);
        }
        if (lvl2done == true)
        {
            level3.gameObject.SetActive(true);
        }
    }

    public void ToggleLevelSelect()
    {
        Debug.Log("I been called");
        isLevelSelectActive = !isLevelSelectActive;

        if (isLevelSelectActive)
        {
            hub.SetActive(false);
            lvl1.SetActive(false);
            lvl2.SetActive(false);
            lvl3.SetActive(false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            levelselect.gameObject.SetActive(true); 
            level1.onClick.AddListener(lvl1clicked);
            level2.onClick.AddListener(lvl2clicked);
            level3.onClick.AddListener(lvl3clicked);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            levelselect.gameObject.SetActive(false); 
            level1.onClick.RemoveListener(lvl1clicked);
            level2.onClick.RemoveListener(lvl2clicked);
            level3.onClick.RemoveListener(lvl3clicked);
        }
    }

    void lvl1clicked()
    {
        if (lvl1done == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            lvl1done = true;
            lvl2done = false;
            Cursor.visible = false;
            levelselect.gameObject.SetActive(false);
            level1.onClick.RemoveListener(lvl1clicked);
            level2.onClick.RemoveListener(lvl2clicked);
            level3.onClick.RemoveListener(lvl3clicked);
            lvl1.SetActive(true);
        }
    }

    void lvl2clicked()
    {
        if (lvl2done == false)
        {
            lvl3done = false;
            Cursor.lockState = CursorLockMode.Locked;
            lvl2done = true;
            Cursor.visible = false;
            levelselect.gameObject.SetActive(false);
            level1.onClick.RemoveListener(lvl1clicked);
            level2.onClick.RemoveListener(lvl2clicked);
            level3.onClick.RemoveListener(lvl3clicked);
            lvl2.SetActive(true);
        }
    }

    void lvl3clicked()
    {
        if (lvl3done == false)
        {
            Cursor.lockState = CursorLockMode.Locked;

            lvl3done = true;
            Cursor.visible = false;
            levelselect.gameObject.SetActive(false);
            level1.onClick.RemoveListener(lvl1clicked);
            level2.onClick.RemoveListener(lvl2clicked);
            level3.onClick.RemoveListener(lvl3clicked);
            lvl3.SetActive(true);
        }
    }
}