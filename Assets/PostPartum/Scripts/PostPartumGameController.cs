using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PostPartumGameController : MonoBehaviour
{
    public GameObject CanvasObject;
    public HapticRythmController _hapticRythmController;
    
    // Start is called before the first frame update
    void Start()
    {
        if (CanvasObject == null)
        {
            CanvasObject = GameObject.FindWithTag("Canvas");
        }
        if (CanvasObject != null)
        {
            CanvasObject.GetComponent<PostPartum.Scripts.CanvasController>().HideAllCanvasImages();
        }

        if (_hapticRythmController == null)
        {
            _hapticRythmController = GetComponent<HapticRythmController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //_hapticRythmController.PlayRythm();
        }
    }

    public void PlayRythm()
    {
        _hapticRythmController.PlayRythm();
    }
}
