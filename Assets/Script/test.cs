using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float forceFactor = 100f;
    List<Rigidbody2D> objectBodies = new List<Rigidbody2D>();

    void Start()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("attracted"))
        {
            var rb = obj.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                continue;
            }
            objectBodies.Add(rb);
        }
    }

    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        Debug.Log("‚¨‚µ‚½");
        foreach (var rb in objectBodies)
        {
            rb.AddForce(GetForce(rb.transform.position));
        }
    }

    Vector3 GetForce(Vector3 pos)
    {
        float dist = Vector3.Distance(transform.position, pos);
        Vector3 dir = (transform.position - pos).normalized;
        return dir / (dist * dist) * forceFactor;
    }
}
