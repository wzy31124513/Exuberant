using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Debug.Log("Collision detected....");
            float dis = (transform.position - other.transform.position).magnitude;
            Debug.Log("dis : " + dis);
            Color co = gameObject.GetComponent<MeshRenderer>().material.color;
            if (dis >= 3 )//&& co.a != 1)
            {
                Debug.Log("greater than 3");
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(co.r, co.g, co.b, 1 - dis * 0.10f);
            }
            else if (dis < 3)
            {
                Debug.Log("less than 3");
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(co.r, co.g, co.b, 1);
            }
        }

    }
}