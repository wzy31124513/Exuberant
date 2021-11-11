using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float axisValueR = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float axisValueL = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        OVRGrabbable grabbable = GetComponent<OVRGrabbable>();
        if (grabbable != null)
        {
            if (grabbable.isGrabbed)
            {
                Debug.Log("is grabbed....");
                Debug.Log("axisValueR...." + axisValueR);

                if ((axisValueR > 0.75f) || (axisValueL > 0.75f))
                {
                    Debug.Log("change the scene....");
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
