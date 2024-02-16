using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombChecker : MonoBehaviour
{

    public GameObject rapScene;
    public GameObject extraComb;
    public AudioClip[] rapClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player (3)")
        {
            if (other.transform.GetChild(0).GetChild(0).GetChild(0).name.Contains("comb"))
            {
                StartCoroutine(GiveComb(other.transform.GetChild(0).GetChild(0).GetChild(0).gameObject));
            }
        }
    }

    IEnumerator GiveComb(GameObject comb)
    {
        FindAnyObjectByType<DialogeScript>().PlayDialoge(new string[] { "Oh thank Goodness! You found my comb! Now i can untangle my hair again.", null }, new string[] { "Rapunzel",null }, rapClips, new float[] { rapClips[0].length, rapClips[1].length });
        extraComb.SetActive(true);
        comb.SetActive(false);
        yield return new WaitForSeconds(rapClips[0].length + rapClips[1].length);
        FindAnyObjectByType<levelui>().ToggleLevelSelect();
        FindAnyObjectByType<levelui>().ToggleLevelSelect();
        rapScene.SetActive(false);
        FindAnyObjectByType<MusicChangeScript>().ChangeMusic();
    }
}
