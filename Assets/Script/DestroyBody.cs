using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBody : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.transform.Find("position/Body").gameObject.transform.position.y < -25)
        {
            Destroy(gameObject);
        }
    }
}
