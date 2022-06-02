using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject target;
    private float offset;
    private Vector3 cameraPosUp;
    private Vector3 initialCameraPos;
    private bool follow;
    private bool iniBoolPos;
    // Start is called before the first frame update
    void Start()
    {
        initialCameraPos = transform.position;
        offset = transform.position.z - target.transform.position.z;
        follow = false;
        iniBoolPos = true;
        cameraPosUp = new Vector3(transform.position.x,transform.position.y+13f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (iniBoolPos)
        {
            transform.position = initialCameraPos;
            if (target.transform.position.y > 4)
            {
                follow = true;
            }
            else if (target.transform.position.y < 1)
            {
                follow = false;
            }
            if (target.transform.position.z < -7)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z-1);
            }
            if (follow)
            {
                
                transform.LookAt(target.transform.position);

            }
          
        }
        else
        {
            PositionUP();
        }
        ChangeCameraPos();
    }

    void PositionUP()
    {
        transform.position = cameraPosUp;
        transform.LookAt(target.transform.position);
    }

    void ChangeCameraPos()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            iniBoolPos = !iniBoolPos;
        }
    }
}
