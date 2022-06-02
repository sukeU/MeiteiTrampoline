using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScript : MonoBehaviour
{
    public GameObject body;
    float time=4.0f;
 

    private void Start()
    {
       
    }

    private void Update()
    {
        float random = Random.value;
        time += Time.deltaTime;
            if (time > 4.0f)
            {
                Instantiate(body, gameObject.transform.position, Quaternion.identity);
                time = 0;
            }
        gameObject.transform.position = new Vector3(random*20-10, 30.0f, 0f);
        
    }
    /*
    Rigidbody[] rbs;
    private GameObject[] ChildObjects;

    private void GetAllChildObject()
    {
        ChildObjects = new GameObject[gameObject.transform.childCount];
        rbs = new Rigidbody[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            ChildObjects[i] = gameObject.transform.GetChild(i).gameObject;
            rbs[i] = ChildObjects[i].GetComponent<Rigidbody>();
        }
    }

    void Start()
    {
        GetAllChildObject();
    }


    void Update()
    {
        if (ChildObjects[0].transform.position.y < -25)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                ChildObjects[i].transform.position = new Vector3(0, 0, 25);
                rbs[i].velocity = Vector3.zero;

            }
            
        }
        
    }
    */
}
