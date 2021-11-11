using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public GameObject gameName;
    public GameObject Abutton, Xbutton;
    public GameObject introPanel, tutorialPanel;
    public GameObject grabbableObject, bench;

    private void Start()
    {
        Abutton.SetActive(true);
        Xbutton.SetActive(false);
        tutorialPanel.SetActive(false);
        introPanel.SetActive(false);
        gameName.GetComponent<Animator>().enabled = false;
        introPanel.GetComponent<Animator>().enabled = false;
        grabbableObject.SetActive(false);
        bench.SetActive(false);
    }
    public void PlayPressed()
    {
        Debug.Log("play pressed....");
        introPanel.SetActive(true);
        gameName.GetComponent<Animator>().enabled = true;
        introPanel.GetComponent<Animator>().enabled = true;
        Abutton.SetActive(false);
        StartCoroutine(XButtonDelay());
    }

    IEnumerator XButtonDelay()
    {
        yield return new WaitForSeconds(1f);

        Xbutton.SetActive(true);
    }    

    public void StartPressed()
    {
        Debug.Log("start pressed....");
        introPanel.SetActive(false);
        Xbutton.SetActive(false);    
        grabbableObject.SetActive(true);
        bench.SetActive(true);
        tutorialPanel.SetActive(true);
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.One))
        {       
                PlayPressed();
           
        }

        if (OVRInput.Get(OVRInput.Button.Three))
        {
            StartPressed();
        }


    }
}
