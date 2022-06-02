using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranpoScript : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        BodyScript script = other.GetComponent<BodyScript>();
        if (script != null)
        {
            script.setTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BodyScript script = other.GetComponent<BodyScript>();
        if (script != null)
        {
            script.setTouch = false;
        }
    }
}
