using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCicleScript : MonoBehaviour
{
    [SerializeField] GameObject obj;
    Vector3 cicle = new Vector3(0, 4, 0);
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = obj.transform.position - cicle;
    

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = obj.transform.position + offset;
    }
}
